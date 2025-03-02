using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.API.Infrastructure.Data.Mapping
{
    internal class TarefaTypeConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> entity)
        {
            entity.ToTable("TB_TAREFA");
            entity.HasKey(e => e.IdTarefa);
            entity.Property(e => e.IdTarefa).HasColumnName("ID_TAREFA");
            entity.Property(e => e.NomeTarefa).HasColumnName("NOME_TAREFA");
            entity.Property(e => e.DescricaoTarefa).HasColumnName("DESCRICAO_TAREFA");
            entity.Property(e => e.SituacaoTarefa).HasColumnName("SITUACAO_TAREFA");
            entity.Property(e => e.PrioridadeTarefa).HasColumnName("PRIORIDADE_TAREFA");
            entity.Property(e => e.DataCriacaoTarefa).HasColumnName("DATA_CRIACAO_TAREFA");
            entity.Property(e => e.DataPrevistaTarefa).HasColumnName("DATA_PREVISTA_TAREFA");
            entity.Property(e => e.DataFinalTarefa).HasColumnName("DATA_FINAL_TAREFA");

            entity
                .HasMany(e => e.Mensagems)
                .WithOne(e => e.Tarefa)
                .HasForeignKey(e => e.TarefaID)
                .HasPrincipalKey(e => e.IdTarefa)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasMany(e => e.HistoricoTarefas)
                .WithOne(e => e.Tarefa)
                .HasForeignKey(e => e.TarefaID)
                .HasPrincipalKey(e => e.IdTarefa)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
