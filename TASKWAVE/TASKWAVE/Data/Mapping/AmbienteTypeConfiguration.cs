using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TASKWAVE.ENTITY.Model;

namespace TASKWAVE.ENTITY.Data.Mapping
{
    internal class AmbienteTypeConfiguration : IEntityTypeConfiguration<Ambiente>
    {
        public void Configure(EntityTypeBuilder<Ambiente> entity)
        {
            entity.ToTable("TB_AMBIENTE");
            entity.HasKey(e => e.IdAmbiente);
            entity.Property(e => e.IdAmbiente).HasColumnName("ID_AMBIENTE");
            entity.Property(e => e.NomeAmbiente).HasColumnName("NOME_AMBIENTE");
            entity.Property(e => e.DescricaoAmbiente).HasColumnName("DESCRICAO_AMBIENTE");

            entity
                .HasMany(e => e.Setores)
                .WithOne(e => e.Ambiente)
                .HasForeignKey(e => e.AmbienteId)
                .HasPrincipalKey(e => e.IdAmbiente)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
