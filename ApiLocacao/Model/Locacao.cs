namespace ApiLocacao.Model
{
    public class Locacao
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdFilme { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Filme IdFilmeNavigation { get; set; } = null!;
    }
}
