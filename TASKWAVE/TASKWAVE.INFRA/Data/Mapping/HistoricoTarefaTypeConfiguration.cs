using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.API.Infrastructure.Data.Mapping
{
    internal class HistoricoTarefaTypeConfiguration : IEntityTypeConfiguration<HistoricoTarefa>
    {
        public void Configure(EntityTypeBuilder<HistoricoTarefa> entity)
        {
            entity.ToTable("TB_HISTORICO_TAREFA");
            entity.HasKey(e => e.IdHistoricoTarefa);
            entity.Property(e => e.IdHistoricoTarefa).HasColumnName("ID_HISTORICO_TAREFA");
            entity.Property(e => e.DataMudancaTarefa).HasColumnName("DATA_MUDANCA_TAREFA");
            entity.Property(e => e.SituacaoAtualTarefa).HasColumnName("SITUACAO_ATUAL_TAREFA");
            entity.Property(e => e.SituacaoAnteriorTarefa).HasColumnName("SITUACAO_ANTERIOR_TAREFA");
            entity.Property(e => e.PrioridadeAtualTarefa).HasColumnName("PRIORIDADE_ATUAL_TAREFA");
            entity.Property(e => e.PrioridadeAnteriorTarefa).HasColumnName("PRIORIDADE_ANTERIOR_TAREFA");

        }
    }
}
