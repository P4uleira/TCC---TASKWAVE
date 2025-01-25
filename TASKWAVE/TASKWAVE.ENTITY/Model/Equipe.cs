using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKWAVE.ENTITY.Model
{
    public class Equipe
    {
        public int IdEquipe { get; set; }
        public string NomeSetor { get; set; }
        public string? DescricaoSetor { get; set; }

        public Equipe()
        {
        }

        public Equipe(int idEquipe, string nomeSetor, string? descricaoSetor)
        {
            IdEquipe = idEquipe;
            NomeSetor = nomeSetor;
            DescricaoSetor = descricaoSetor;
        }
    }
}
