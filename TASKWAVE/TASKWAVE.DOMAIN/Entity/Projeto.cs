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

        public Projeto(string nomeProjeto, string? descricaoProjeto, DateTime dataCriacaoProjeto)
        {
            NomeProjeto = nomeProjeto;
            DescricaoProjeto = descricaoProjeto;
            DataCriacaoProjeto = dataCriacaoProjeto;
        }

        public Projeto(string nomeProjeto, string? descricaoProjeto, DateTime dataCriacaoProjeto, ICollection<Equipe> equipes)
        {
            NomeProjeto = nomeProjeto;
            DescricaoProjeto = descricaoProjeto;
            DataCriacaoProjeto = dataCriacaoProjeto;
            Equipes = equipes;
        }

    }
}
