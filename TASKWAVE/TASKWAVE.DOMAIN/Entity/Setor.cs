
namespace TASKWAVE.DOMAIN.ENTITY
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

        public Setor(string sectorName, string? sectorDescription, int ambienteId)
        {
            NomeSetor = sectorName;
            DescricaoSetor = sectorDescription;
            AmbienteId = ambienteId;
        }
    }
}
