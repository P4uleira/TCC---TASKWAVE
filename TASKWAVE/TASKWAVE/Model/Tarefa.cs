using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKWAVE.ENTITY.Model
{
    public class Tarefa
    {
        public int IdTarefa { get; set; }
        public string NomeTarefa { get; set; }
        public string DescricaoTarefa { get; set; }
        public string SituacaoTarefa { get; set; }
        public string PrioridadeTarefa { get; set; }
        public DateTime DataCriacaoTarefa { get; set; }
        public DateTime DataPrevistaTarefa { get; set; }
        public DateTime DataFinalTarefa { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }

        public Tarefa()
        {
        }

        public Tarefa(int idTarefa, string nomeTarefa, string descricaoTarefa, string situacaoTarefa, string prioridadeTarefa, DateTime dataCriacaoTarefa, DateTime dataPrevistaTarefa, DateTime dataFinalTarefa)
        {
            IdTarefa = idTarefa;
            NomeTarefa = nomeTarefa;
            DescricaoTarefa = descricaoTarefa;
            SituacaoTarefa = situacaoTarefa;
            PrioridadeTarefa = prioridadeTarefa;
            DataCriacaoTarefa = dataCriacaoTarefa;
            DataPrevistaTarefa = dataPrevistaTarefa;
            DataFinalTarefa = dataFinalTarefa;
        }
    }
}
