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
    internal class ProjetoTypeConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> entity)
        {
            entity.ToTable("TB_PROJETO");
            entity.Property(e => e.IdProjeto).HasColumnName("ID_PROJETO");
            entity.Property(e => e.NomeProjeto).HasColumnName("NOME_PROJETO");
            entity.Property(e => e.DescricaoProjeto).HasColumnName("DESCRICAO_PROJETO");
        }
    }
}
