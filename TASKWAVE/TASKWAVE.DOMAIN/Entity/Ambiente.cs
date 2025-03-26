namespace TASKWAVE.DOMAIN.ENTITY
{
    public class Ambiente
    {
        public int IdAmbiente { get; set; }
        public string NomeAmbiente { get; set; }
        public string? DescricaoAmbiente { get; set; }

        public ICollection<Setor> Setores { get; }

        public Ambiente()
        {
        }

        public Ambiente(string environmentName, string? environmentDescription)
        {
            NomeAmbiente = environmentName;
            DescricaoAmbiente = environmentDescription;
        }
    }
}
