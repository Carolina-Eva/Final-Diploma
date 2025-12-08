namespace BE
{
    public class TierraLibre : IEstadoParcela
    {
        public void Plantar(Parcela parcela)
        {
            parcela.SetEstado(new SemillaPlantada());
        }

        public void Regar(Parcela parcela)
        {
            // No hace nada, tierra vacía no se riega
        }

        public void Cosechar(Parcela parcela)
        {
            // No hay nada para cosechar
        }
    }
}
