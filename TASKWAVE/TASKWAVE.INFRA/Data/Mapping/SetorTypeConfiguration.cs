using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.API.Infrastructure.Data.Mapping
{
    internal class SetorTypeConfiguration : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> entity)
        {
            entity.ToTable("TB_SETOR");
            entity.HasKey(e => e.IdSetor);
            entity.Property(e => e.IdSetor).HasColumnName("ID_SETOR");
            entity.Property(e => e.NomeSetor).HasColumnName("NOME_SETOR");
            entity.Property(e => e.DescricaoSetor).HasColumnName("DESCRICAO_SETOR");

            entity
                .HasMany(e => e.Equipes)
                .WithOne(e => e.Setor)
                .HasForeignKey(e => e.SetorId)
                .HasPrincipalKey(e => e.IdSetor)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
