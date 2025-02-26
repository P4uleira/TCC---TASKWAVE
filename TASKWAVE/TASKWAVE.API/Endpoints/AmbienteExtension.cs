using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TASKWAVE.API.Infrastructure.Data;
using TASKWAVE.API.Responses;

namespace TASKWAVE.API.Endpoints
{
    public static class AmbienteExtension
    {
        public static void AddEndPointAmbiente(this WebApplication app)
        {
            app.MapGet("/ambiente", async ([FromServices] TaskWaveContext context) =>
            {
                var ambientes = await context.Ambientes.ToListAsync();

                var ambientesResponse = ambientes.Select(a => new AmbienteResponse(

                    IdAmbiente: a.IdAmbiente,
                    NomeAmbiente: a.NomeAmbiente,
                    DescricaoAmbiente: a.DescricaoAmbiente
                )).ToList();

                return Results.Ok(ambientesResponse);

            });
        }
    }
}
