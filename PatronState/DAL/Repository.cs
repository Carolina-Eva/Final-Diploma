using BE;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Repository
    {
        private AccesoDatos _acceso;

        public Repository()
        {
            _acceso = new AccesoDatos();
        }

        public async Task<bool> GuardarParcela(Parcela parcela)
        {
            string sql = $"SP_GUARDAR_PARCELA";
            var parameters = new List<SqlParameter>
            {
                _acceso.CrearParametro("@EstadoActual", parcela.ObtenerNombreEstado()),
                _acceso.CrearParametro("@Nombre", parcela.Nombre),
                _acceso.CrearParametro("@FechaUltimoCambio", parcela.FechaUltimoCambio)
            };
            int result = await _acceso.Escribir(sql, parameters);
            return result > 0;
        }

        public async Task<bool> GuardarEstado(Parcela parcela)
        {
            string sql = $"SP_GUARDAR_ESTADO";

            var parameters = new List<SqlParameter>
            {
                _acceso.CrearParametro("@Id", parcela.Id),
                _acceso.CrearParametro("@EstadoActual", parcela.ObtenerNombreEstado())
            };

            int result = await _acceso.Escribir(sql, parameters);
            return result > 0;
        }

        public async Task<int> ObtenerTotalCosechas()
        {
            string sql = "SP_TOTAL_COSECHAS";

            var table = await _acceso.ObtenerData(sql);

            if (table.Rows.Count > 0)
                return Convert.ToInt32(table.Rows[0]["TotalCosechas"]);

            return 0;
        }

        public async Task<DataTable> ObtenerCosechasPorParcela()
        {
            string sql = "SP_TOTAL_COSECHAS_PARCELA";

            return await _acceso.ObtenerData(sql);
        }


        public async Task<List<Parcela>> ListarParcelas()
        {
            string sql = $"SP_OBTENER_PARCELAS";
            var table = await _acceso.ObtenerData(sql);
            var list = new List<Parcela>();

            foreach (DataRow row in table.Rows)
            {
                Parcela parcela = new Parcela();

                parcela.Id = Convert.ToInt32(row["Id"]);
                parcela.Nombre = row["Nombre"] != DBNull.Value ? row["Nombre"]!.ToString()! : string.Empty;
                var estadoStr = row["EstadoActual"] != DBNull.Value ? row["EstadoActual"]!.ToString()! : string.Empty;
                parcela.InicializarEstadoDesdeString(estadoStr);
                parcela.FechaUltimoCambio = Convert.ToDateTime(row["FechaUltimoCambio"]);

                list.Add(parcela);
            }
            return list;
        }
    }
}
