namespace TASKWAVE.DOMAIN.ENTITY
{
    public class Projeto
    {
        public int IdProjeto { get; set; }
        public string NomeProjeto { get; set; }
        public string? DescricaoProjeto { get; set; }
        public DateTime DataCriacaoProjeto { get; set; }
        public ICollection<Equipe> Equipes { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; }

        public Projeto()
        {
        }

        public Projeto(string projectName, string? projectDescription, DateTime projectCreationDate)
        {
            NomeProjeto = projectName;
            DescricaoProjeto = projectDescription;
            DataCriacaoProjeto = projectCreationDate;
        }

        public Projeto(string projectName, string? projectDescription, DateTime projectCreationDate, ICollection<Equipe> teams)
        {
            NomeProjeto = projectName;
            DescricaoProjeto = projectDescription;
            DataCriacaoProjeto = projectCreationDate;
            Equipes = teams;
        }

    }
}
