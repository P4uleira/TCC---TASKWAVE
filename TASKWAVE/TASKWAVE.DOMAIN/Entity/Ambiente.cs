namespace TASKWAVE.API.Infrastructure.Model
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

        public Ambiente(string nomeAmbiente, string? descricaoAmbiente)
        {
            NomeAmbiente = nomeAmbiente;
            DescricaoAmbiente = descricaoAmbiente;
        }
    }
}
