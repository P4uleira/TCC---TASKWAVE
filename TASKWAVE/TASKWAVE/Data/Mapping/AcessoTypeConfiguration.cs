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
    internal class AcessoTypeConfiguration : IEntityTypeConfiguration<Acesso>
    {
        public void Configure(EntityTypeBuilder<Acesso> entity)
        {
            entity.ToTable("TB_ACESSO");
            entity.Property(e => e.IdAcesso).HasColumnName("ID_ACESSO");
            entity.Property(e => e.NomeAcesso).HasColumnName("NOME_ACESSO");
            entity.Property(e => e.DescricaoAcesso).HasColumnName("DESCRICAO_ACESSO");
            entity.Property(e => e.DataCriacaoAcesso).HasColumnName("DATA_CRIACAO_ACESSO");

            entity.HasMany(e => e.Usuarios)
              .WithMany(p => p.Acessos)
              .UsingEntity<Dictionary<string, object>>(
                  "TB_ACESSO_USUARIO",
                  l => l.HasOne<Usuario>()
                        .WithMany()
                        .HasForeignKey("USUARIO_ID")
                        .HasConstraintName("FK_USUARIO_ID"),
                  r => r.HasOne<Acesso>()
                        .WithMany()
                        .HasForeignKey("ACESSO_ID")
                        .HasConstraintName("FK_ACESSO_ID"),
                  j =>
                  {
                      j.HasKey("ACESSO_ID", "USUARIO_ID");
                      j.ToTable("TB_ACESSO_USUARIO");
                  }
              );
        }
    }
}
