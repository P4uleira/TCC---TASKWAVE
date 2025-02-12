using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TASKWAVE.ENTITY.Model;

namespace TASKWAVE.ENTITY.Data.Mapping
{
    internal class EquipeTypeConfiguration : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> entity)
        {
            entity.ToTable("TB_EQUIPE");
            entity.HasKey(e => e.IdEquipe);
            entity.Property(e => e.IdEquipe).HasColumnName("ID_EQUIPE");
            entity.Property(e => e.NomeEquipe).HasColumnName("NOME_EQUIPE");
            entity.Property(e => e.DescricaoEquipe).HasColumnName("DESCRICAO_EQUIPE");

            entity.HasMany(e => e.Projetos)
              .WithMany(p => p.Equipes)
              .UsingEntity<Dictionary<string, object>>(
                  "TB_EQUIPE_PROJETO",
                  l => l.HasOne<Projeto>()
                        .WithMany()
                        .HasForeignKey("PROJETO_ID")
                        .HasConstraintName("FK_PROJETO_ID"),
                  r => r.HasOne<Equipe>()
                        .WithMany()
                        .HasForeignKey("EQUIPE_ID")
                        .HasConstraintName("FK_EQUIPE_ID"),
                  j =>
                  {
                      j.HasKey("EQUIPE_ID", "PROJETO_ID");
                      j.ToTable("TB_EQUIPE_PROJETO");
                  }
              );
               
            entity.HasMany(e => e.Usuarios)
              .WithMany(p => p.Equipes)
              .UsingEntity<Dictionary<string, object>>(
                  "TB_EQUIPE_USUARIO",
                  l => l.HasOne<Usuario>()
                        .WithMany()
                        .HasForeignKey("USUARIO_ID")
                        .HasConstraintName("FK_USUARIO_ID"),
                  r => r.HasOne<Equipe>()
                        .WithMany()
                        .HasForeignKey("EQUIPE_ID")
                        .HasConstraintName("FK_EQUIPE_ID"),
                  j =>
                  {
                      j.HasKey("EQUIPE_ID", "USUARIO_ID");
                      j.ToTable("TB_EQUIPE_USUARIO");
                  }
              );
        }
    }
}
