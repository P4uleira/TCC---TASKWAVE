using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.API.Infrastructure.Data.Mapping
{
    internal class ProjetoTypeConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> entity)
        {

            entity.ToTable("TB_PROJETO");
            entity.HasKey(e => e.IdProjeto);
            entity.Property(e => e.IdProjeto).HasColumnName("ID_PROJETO");
            entity.Property(e => e.NomeProjeto).HasColumnName("NOME_PROJETO");
            entity.Property(e => e.DescricaoProjeto).HasColumnName("DESCRICAO_PROJETO");
            entity.Property(e => e.DataCriacaoProjeto).HasColumnName("DATA_CRIACAO_PROJETO");

            entity
                .HasMany(e => e.Tarefas)
                .WithOne(e => e.Projeto)
                .HasForeignKey(e => e.ProjetoId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
