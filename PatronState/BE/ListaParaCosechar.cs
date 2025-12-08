namespace BE
{
    public class ListaParaCosechar : IEstadoParcela
    {
        public void Plantar(Parcela parcela) { }

        public void Regar(Parcela parcela) { }

        public void Cosechar(Parcela parcela)
        {
            parcela.SetEstado(new TierraLibre());
        }
    }
}
