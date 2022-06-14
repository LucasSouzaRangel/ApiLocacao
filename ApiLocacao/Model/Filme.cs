namespace ApiLocacao.Model
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;  
        public int ClassificacaoIndicativa { get; set; }
        public DateTime Lancamento { get; set; }
    }
}
