using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TASKWAVE.DOMAIN.ENTITY;

namespace TASKWAVE.INFRA.Data.Mapping
{
    internal class UsuarioTypeConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.ToTable("TB_USUARIO");
            entity.HasKey(e => e.IdUsuario);
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.NomeUsuario).HasColumnName("NOME_USUARIO");
            entity.Property(e => e.EmailUsuario).HasColumnName("EMAIL_USUARIO");
            entity.Property(e => e.SenhaUsuario).HasColumnName("SENHA_USUARIO");
            entity.Property(e => e.DataCriacaoUsuario).HasColumnName("DATA_CRIACAO_USUARIO");

        }
    }
}
