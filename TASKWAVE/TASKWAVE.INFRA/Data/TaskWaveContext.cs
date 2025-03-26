using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TASKWAVE.DOMAIN.ENTITY;


namespace TASKWAVE.INFRA.Data
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
                optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information); //estou definindo que a saida de log será no console e so aparecerá informação.
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
