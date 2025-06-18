using Microsoft.EntityFrameworkCore;
using TASKWAVE.DOMAIN.Interfaces.Repositories;
using TASKWAVE.DOMAIN.Interfaces.Services;
using TASKWAVE.DOMAIN.Services;
using TASKWAVE.INFRA.Data;
using TASKWAVE.INFRA.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskWaveContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//service inject
builder.Services.AddScoped<IAmbienteRepository, AmbienteRepository>();
builder.Services.AddScoped<IAmbienteService, AmbienteService>();

builder.Services.AddScoped<ISetorRepository, SetorRepository>();
builder.Services.AddScoped<ISetorService, SetorService>();

builder.Services.AddScoped<IEquipeRepository, EquipeRepository>();
builder.Services.AddScoped<IEquipeService, EquipeService>();

builder.Services.AddScoped<IProjetoRepository, ProjetoRepository>();
builder.Services.AddScoped<IProjetoService, ProjetoService>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IAcessoRepository, AcessoRepository>();
builder.Services.AddScoped<IAcessoService, AcessoService>();

builder.Services.AddScoped<IMensagemRepository, MensagemRepository>();
builder.Services.AddScoped<IMensagemService, MensagemService>();

builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<ITarefaService, TarefaService>();

builder.Services.AddScoped<IHistoricoTarefaRepository, HistoricoTarefaRepository>();
builder.Services.AddScoped<IHistoricoTarefaService, HistoricoTarefaService>();

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7175") // URL do seu Blazor
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<TaskWaveContext>();
dbContext.Database.Migrate();

app.UseSwagger();
app.UseCors();
app.UseSwaggerUI();
app.MapControllers();
app.UseHttpsRedirection();


app.Run();
