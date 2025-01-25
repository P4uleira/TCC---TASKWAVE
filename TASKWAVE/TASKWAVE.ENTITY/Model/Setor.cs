using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKWAVE.ENTITY.Model
{
    public class Setor
    {
        public int IdSetor { get; set; }
        public string NomeSetor { get; set; }
        public string? DescricaoSetor { get; set; }

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
