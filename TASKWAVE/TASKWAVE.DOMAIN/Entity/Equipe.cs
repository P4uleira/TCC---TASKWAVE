namespace TASKWAVE.DOMAIN.ENTITY
{
    public class Equipe
    {
        public int IdEquipe { get; set; }
        public string NomeEquipe { get; set; }
        public string? DescricaoEquipe { get; set; }

        public int SetorId { get; set; }
        public Setor Setor { get; set; }
        public ICollection<Projeto> Projetos { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }

        public Equipe()
        {
        }

        public Equipe(string nomeEquipe, string? descricaoEquipe, int setorId)
        {
            NomeEquipe = nomeEquipe;
            DescricaoEquipe = descricaoEquipe;
            SetorId = setorId;
        }
    }
}
