CREATE TABLE Parcela (
    Id INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(50),
    EstadoActual VARCHAR(50),
    FechaUltimoCambio DATETIME
);

CREATE TABLE LogEstadoParcela (
    IdLog INT PRIMARY KEY IDENTITY,
    ParcelaId INT NOT NULL,
    Estado VARCHAR(50) NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

ALTER TABLE LogEstadoParcela
ADD CONSTRAINT FK_LogEstado_Parcela
FOREIGN KEY (ParcelaId) REFERENCES Parcela(Id);

INSERT INTO Parcela (Nombre, EstadoActual, FechaUltimoCambio)
VALUES 
('Parcela 1', 'TierraLibre', SYSDATETIME()),
('Parcela 2', 'SemillaPlantada', SYSDATETIME()),
('Parcela 3', 'Creciendo', SYSDATETIME()),
('Parcela 4', 'ListaParaCosechar', SYSDATETIME());

CREATE PROCEDURE SP_OBTENER_PARCELAS
AS
BEGIN
    SELECT Id, Nombre, EstadoActual, FechaUltimoCambio
    FROM Parcela;
END;

CREATE PROCEDURE SP_GUARDAR_ESTADO
(
    @Id INT,
    @EstadoActual VARCHAR(50)
)
AS
BEGIN
    SET NOCOUNT ON;

    -- 1) Actualizar estado actual en la tabla Parcela
    UPDATE Parcela
    SET EstadoActual = @EstadoActual,
        FechaUltimoCambio = SYSDATETIME()
    WHERE Id = @Id;

    -- 2) Registrar log de estado (auditoría)
    INSERT INTO LogEstadoParcela (ParcelaId, Estado, Fecha)
    VALUES (@Id, @EstadoActual, SYSDATETIME());
END;

CREATE PROCEDURE SP_TOTAL_COSECHAS
AS
BEGIN
    SET NOCOUNT ON;
	SELECT COUNT(*) AS TotalCosechas
	FROM LogEstadoParcela
	WHERE Estado = 'ListaParaCosechar';
END


CREATE PROCEDURE SP_TOTAL_COSECHAS_PARCELA
AS
BEGIN
	SELECT p.Nombre, COUNT(l.IdLog) AS CantidadCosechas
	FROM Parcela p
	LEFT JOIN LogEstadoParcela l ON p.Id = l.ParcelaId AND l.Estado = 'ListaParaCosechar'
	GROUP BY p.Nombre
	ORDER BY CantidadCosechas DESC;
END



