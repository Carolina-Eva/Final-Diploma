namespace BE
{
    public interface IEstadoParcela
    {
        void Plantar(Parcela parcela);
        void Regar(Parcela parcela);
        void Cosechar(Parcela parcela);
    }
}
