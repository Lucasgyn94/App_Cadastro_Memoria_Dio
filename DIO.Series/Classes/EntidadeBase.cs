namespace DIO.Series
{
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; } // O protected faz com que seja acessado somente dentro da própria Dll

    }
}