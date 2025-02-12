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
        public string NomeEquipe { get; set; }
        public string? DescricaoEquipe { get; set; }

        public int SetorId { get; set; }
        public Setor Setor { get; set; }
        public ICollection<Projeto> Projetos { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }

        public Equipe()
        {
        }

        public Equipe(int idEquipe, string nomeEquipe, string? descricaoEquipe)
        {
            IdEquipe = idEquipe;
            NomeEquipe = nomeEquipe;
            DescricaoEquipe = descricaoEquipe;
        }
    }
}
