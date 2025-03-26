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

        public Usuario(string nomeUsuario, string emailUsuario, string senhaUsuario, DateTime dataCriacaoUsuario)
        {
            NomeUsuario = nomeUsuario;
            EmailUsuario = emailUsuario;
            SenhaUsuario = senhaUsuario;
            DataCriacaoUsuario = dataCriacaoUsuario;
        }

        public Usuario(string nomeUsuario, string emailUsuario, string senhaUsuario, DateTime dataCriacaoUsuario, ICollection<Equipe> equipes) 
        {
            NomeUsuario= nomeUsuario;
            EmailUsuario = emailUsuario;    
            SenhaUsuario = senhaUsuario;
            DataCriacaoUsuario = dataCriacaoUsuario;
            Equipes = equipes;
        }
    }
}
