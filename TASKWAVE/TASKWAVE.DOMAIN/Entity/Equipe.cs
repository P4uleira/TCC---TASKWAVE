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

        public Equipe(string teamName, string? teamDescription, int sectorId)
        {
            NomeEquipe = teamName;
            DescricaoEquipe = teamDescription;
            SetorId = sectorId;
        }
    }
}
