namespace TASKWAVE.API.Infrastructure.Model
{
    public class Projeto
    {
        public int IdProjeto { get; set; }
        public string NomeProjeto { get; set; }
        public string? DescricaoProjeto { get; set; }
        public DateTime DataCriacaoProjeto { get; set; }
        public ICollection<Equipe> Equipes { get; }
        public ICollection<Tarefa> Tarefas { get; }
        public Projeto()
        {
        }

        public Projeto(int idProjeto, string nomeProjeto, string? descricaoProjeto, DateTime dataCriacaoProjeto)
        {
            IdProjeto = idProjeto;
            NomeProjeto = nomeProjeto;
            DescricaoProjeto = descricaoProjeto;
            DataCriacaoProjeto = dataCriacaoProjeto;
        }
    }
}
