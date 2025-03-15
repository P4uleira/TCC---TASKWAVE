namespace TASKWAVE.API.Infrastructure.Model
{
    public class Acesso
    {
        public int IdAcesso { get; set; }
        public string NomeAcesso { get; set; }
        public string? DescricaoAcesso { get; set; }
        public DateTime DataCriacaoAcesso { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
        public Acesso()
        {
        }

        public Acesso(string nomeAcesso, string? descricaoAcesso, DateTime dataCriacaoAcesso)
        {
            NomeAcesso = nomeAcesso;
            DescricaoAcesso = descricaoAcesso;
            DataCriacaoAcesso = dataCriacaoAcesso;
        }
    }
}
