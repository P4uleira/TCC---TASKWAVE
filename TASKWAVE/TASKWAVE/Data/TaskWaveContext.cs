using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TASKWAVE.ENTITY.Model;

namespace TASKWAVE.ENTITY.Data
{
    public class TaskWaveContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public TaskWaveContext(DbContextOptions<TaskWaveContext> options) : base(options)
        {
        }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ConnectionStrings:DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskWaveContext).Assembly);
        }

        public DbSet<Ambiente> Ambientes { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<HistoricoTarefa> HistoricoTarefas { get; set; }
        public DbSet<Acesso> Acessos { get; set; }
    }
}
