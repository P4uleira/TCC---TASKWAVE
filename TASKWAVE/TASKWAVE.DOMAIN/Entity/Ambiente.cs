using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Ambiente(int idAmbiente, string nomeAmbiente, string? descricaoAmbiente)
        {
            IdAmbiente = idAmbiente;
            NomeAmbiente = nomeAmbiente;
            DescricaoAmbiente = descricaoAmbiente;
        }
    }
}
