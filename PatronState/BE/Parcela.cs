namespace BE
{
    public class Parcela
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaUltimoCambio { get; set; }
        public IEstadoParcela Estado { get; private set; }

        public Parcela(){}

        // Se recibe un nombre de estado desde BD y se convierte al objeto concreto TODO: Mejorar con Reflection
        public void InicializarEstadoDesdeString(string estado)
        {
            Estado = estado switch
            {
                "TierraLibre" => new TierraLibre(),
                "SemillaPlantada" => new SemillaPlantada(),
                "Creciendo" => new Creciendo(),
                "ListaParaCosechar" => new ListaParaCosechar(),
                _ => new TierraLibre()
            };
        }

        public string ObtenerNombreEstado()
            => Estado.GetType().Name;

        public void SetEstado(IEstadoParcela nuevoEstado)
        {
            Estado = nuevoEstado;
            FechaUltimoCambio = DateTime.Now;
        }

        public void Plantar() => Estado.Plantar(this);
        public void Regar() => Estado.Regar(this);
        public void Cosechar() => Estado.Cosechar(this);

    }
}
