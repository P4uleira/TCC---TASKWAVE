
namespace TASKWAVE.API.Infrastructure.Model
{
    public class Setor
    {
        public int IdSetor { get; set; }
        public string NomeSetor { get; set; }
        public string? DescricaoSetor { get; set; }

        public int AmbienteId { get; set; }
        public Ambiente Ambiente { get; set; }

        public ICollection<Equipe> Equipes { get; set; }

        public Setor()
        {
        }

        public Setor(string nomeSetor, string? descricaoSetor, int ambienteId)
        {
            NomeSetor = nomeSetor;
            DescricaoSetor = descricaoSetor;
            AmbienteId = ambienteId;
        }
    }
}
