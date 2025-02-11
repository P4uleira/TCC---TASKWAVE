using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKWAVE.ENTITY.Model
{
    public class Projeto
    {
        public int IdProjeto { get; set; }
        public string NomeProjeto { get; set; }
        public string? DescricaoProjeto { get; set; }
        public DateTime DataCriacaoProjeto { get; set; }
        public List<Equipe> Equipes { get; }
        public List<Tarefa> Tarefas { get; }
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
