namespace TASKWAVE.DOMAIN.ENTITY
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

        public Acesso(string accessName, string? accessDescription, DateTime accessCreationDate)
        {
            NomeAcesso = accessName;
            DescricaoAcesso = accessDescription;
            DataCriacaoAcesso = accessCreationDate;
        }
    }
}
