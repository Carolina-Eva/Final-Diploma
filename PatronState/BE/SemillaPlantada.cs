namespace BE
{
    public class SemillaPlantada : IEstadoParcela
    {
        public void Plantar(Parcela parcela)
        {
            // No se puede plantar encima
        }

        public void Regar(Parcela parcela)
        {
            parcela.SetEstado(new Creciendo());
        }

        public void Cosechar(Parcela parcela)
        {
            // No se puede cosechar todavía
        }
    }
}
