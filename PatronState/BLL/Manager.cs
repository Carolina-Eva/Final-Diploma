using BE;
using DAL;
using System.Data;
namespace BLL
{
    public class Manager
    {
        private Repository _repository;

        public Manager()
        {
            _repository = new Repository();
        }
        public async Task<bool> GuardarEstadoAsync(List<Parcela> parcelas)
        {
            bool allSaved = true;
            foreach (var parcela in parcelas)
            {
                bool saved = await _repository.GuardarEstado(parcela);
                if (!saved)
                {
                    allSaved = false;
                }
            }
            return allSaved;
        }

        public async Task<List<Parcela>> ListarParcelasAsync()
        {
            return await _repository.ListarParcelas();
        }

        public async Task<int> ObtenerTotalCosechasAsync()
        {
            return await _repository.ObtenerTotalCosechas();
        }

        public async Task<DataTable> ObtenerCosechasPorParcelaAsync()
        {
            return await _repository.ObtenerCosechasPorParcela();
        }


    }
}
