using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TASKWAVE.DOMAIN.ENTITY;
using TASKWAVE.DOMAIN.Enums;

namespace TASKWAVE.INFRA.Data.Mapping
{
    internal class HistoricoTarefaTypeConfiguration : IEntityTypeConfiguration<HistoricoTarefa>
    {
        public void Configure(EntityTypeBuilder<HistoricoTarefa> entity)
        {
            entity.ToTable("TB_HISTORICO_TAREFA");
            entity.HasKey(e => e.IdHistoricoTarefa);
            entity.Property(e => e.IdHistoricoTarefa).HasColumnName("ID_HISTORICO_TAREFA");
            entity.Property(e => e.DataMudancaTarefa).HasColumnName("DATA_MUDANCA_TAREFA");
            entity.Property(e => e.SituacaoAtualTarefa).HasColumnName("SITUACAO_ATUAL_TAREFA").HasConversion(new EnumToStringConverter<SituacaoTarefaEnum>());
            entity.Property(e => e.SituacaoAnteriorTarefa).HasColumnName("SITUACAO_ANTERIOR_TAREFA").HasConversion(new EnumToStringConverter<SituacaoTarefaEnum>());
            entity.Property(e => e.PrioridadeAtualTarefa).HasColumnName("PRIORIDADE_ATUAL_TAREFA").HasConversion(new EnumToStringConverter<PrioridadeTarefaEnum>());
            entity.Property(e => e.PrioridadeAnteriorTarefa).HasColumnName("PRIORIDADE_ANTERIOR_TAREFA").HasConversion(new EnumToStringConverter<PrioridadeTarefaEnum>());

        }
    }
}
