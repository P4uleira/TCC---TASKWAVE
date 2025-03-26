using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TASKWAVE.DOMAIN.ENTITY;

namespace TASKWAVE.INFRA.Data.Mapping
{
    internal class MensagemTypeConfiguration : IEntityTypeConfiguration<Mensagem>
    {
        public void Configure(EntityTypeBuilder<Mensagem> entity)
        {
            entity.ToTable("TB_MENSAGEM");
            entity.HasKey(e => e.IdMensagem);
            entity.Property(e => e.IdMensagem).HasColumnName("ID_MENSAGEM");
            entity.Property(e => e.ConteudoMensagem).HasColumnName("CONTEUDO_MENSAGEM");
            entity.Property(e => e.DataEnvioMensagem).HasColumnName("DATA_ENVIO_MENSAGEM");

        }
    }
}
