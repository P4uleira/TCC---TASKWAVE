﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.API.Infrastructure.Data.Mapping
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
