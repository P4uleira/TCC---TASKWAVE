using Microsoft.EntityFrameworkCore;
using TASKWAVE.API.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TaskWaveContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.Run();
