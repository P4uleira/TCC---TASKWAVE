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
    internal class SetorTypeConfiguration : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> entity)
        {
            entity.ToTable("TB_SETOR");
            entity.Property(e => e.IdSetor).HasColumnName("ID_SETOR");
            entity.Property(e => e.NomeSetor).HasColumnName("NOME_SETOR");
            entity.Property(e => e.DescricaoSetor).HasColumnName("DESCRICAO_SETOR");
        }
    }
}
