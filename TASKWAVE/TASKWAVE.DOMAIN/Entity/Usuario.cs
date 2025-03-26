namespace TASKWAVE.DOMAIN.ENTITY
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public DateTime DataCriacaoUsuario { get; set; }
        public ICollection<Equipe> Equipes { get; set; }
        public ICollection<Acesso> Acessos { get; set; }

        public Usuario()
        {
        }
        public Usuario(string userName, string userEmail, string userPassword, DateTime userCreationDate)
        {
            NomeUsuario = userName;
            EmailUsuario = userEmail;
            SenhaUsuario = userPassword;
            DataCriacaoUsuario = userCreationDate;
        }

        public Usuario(string userName, string userEmail, string userPassword, DateTime userCreationDate, ICollection<Equipe> teams)
        {
            NomeUsuario = userName;
            EmailUsuario = userEmail;
            SenhaUsuario = userPassword;
            DataCriacaoUsuario = userCreationDate;
            Equipes = teams;
        }
    }
}
