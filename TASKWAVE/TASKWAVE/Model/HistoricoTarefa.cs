﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKWAVE.ENTITY.Model
{
    public class HistoricoTarefa
    {
        public int IdHistoricoTarefa { get; set; }
        public DateTime DataMudancaTarefa { get; set; }
        public string SituacaoAtualTarefa { get; set; }
        public string SituacaoAnteriorTarefa { get; set; }
        public string PrioridadeAtualTarefa { get; set; }
        public string PrioridadeAnteriorTarefa { get; set; }

        public HistoricoTarefa()
        {
        }

        public HistoricoTarefa(int idHistoricoTarefa, DateTime dataMudancaTarefa, string situacaoAtualTarefa, string situacaoAnteriorTarefa, string prioridadeAtualTarefa, string prioridadeAnteriorTarefa)
        {
            IdHistoricoTarefa = idHistoricoTarefa;
            DataMudancaTarefa = dataMudancaTarefa;
            SituacaoAtualTarefa = situacaoAtualTarefa;
            SituacaoAnteriorTarefa = situacaoAnteriorTarefa;
            PrioridadeAtualTarefa = prioridadeAtualTarefa;
            PrioridadeAnteriorTarefa = prioridadeAnteriorTarefa;
        }
    }
}