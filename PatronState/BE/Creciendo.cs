namespace BE
{
    public class Creciendo : IEstadoParcela
    {
        public void Plantar(Parcela parcela) { }

        public void Regar(Parcela parcela)
        {
            parcela.SetEstado(new ListaParaCosechar());
        }

        public void Cosechar(Parcela parcela) { }
    }
}
