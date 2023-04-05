using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace ConciergeBackend.Models
{
    public class Audit
    {
        public string id { get; set; }
        public string userID { get; set; }
        public DateTime timestamp { get; set; }
        public string table { get; set; }
        public string field { get; set; }
        public string action { get; set; }
        public string oldvalue { get; set; }
        public string newvalue { get; set; }
        public string comments { get; set; }
    }


public static class AuditEndpoints
{
	public static void MapAuditEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Audit").WithTags(nameof(Audit));

        group.MapGet("/", () =>
        {
            return new [] { new Audit() };
        })
        .WithName("GetAllAudits")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new Audit { ID = id };
        })
        .WithName("GetAuditById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Audit input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateAudit")
        .WithOpenApi();

        group.MapPost("/", (Audit model) =>
        {
            //return TypedResults.Created($"/Audits/{model.ID}", model);
        })
        .WithName("CreateAudit")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Audit { ID = id });
        })
        .WithName("DeleteAudit")
        .WithOpenApi();
    }
}}
