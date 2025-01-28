using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TASKWAVE.ENTITY.Model
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

        public Setor(int idSetor, string nomeSetor, string? descricaoSetor)
        {
            IdSetor = idSetor;
            NomeSetor = nomeSetor;
            DescricaoSetor = descricaoSetor;
        }
    }
}
