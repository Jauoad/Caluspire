using Caluspire.ApiService.GraphQL.Queries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Caluspire.Infrastructure;
using Caluspire.Infrastructure.Repositories;
using Caluspire.Domain.Repositories;
using MediatR;
using Caluspire.Application.Commands;
using Caluspire.Application.Handlers;
using Caluspire.Application.DTOs;
using Caluspire.ApiService.GraphQL.Hubs;
using Caluspire.Application.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();
builder.Services.AddMediatR(typeof(Program));

builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

builder.Services.AddScoped<IRequestHandler<SubmitJobApplicationCommand, bool>, SubmitJobApplicationCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetJobApplicationStatusQuery, ApplicationStatusDto>, GetJobApplicationStatusQueryHandler>();

builder.Services.AddSignalR();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<JobQuery>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("JobApplicationDb");
});

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapHub<JobApplicationHub>("/jobApplicationHub");

app.MapPost("/jobApplications", async (SubmitJobApplicationCommandHandler command, IMediator mediator) =>
{
    var result = await mediator.Send(command);

    if (result is bool isSuccess && isSuccess)
    {
        return Results.Ok();
    }
    else
    {
        return Results.BadRequest("Error submitting job application");
    }
});

app.MapGet("/jobApplications/{candidateId}", async (int candidateId, IMediator mediator) =>
{
    var query = new GetJobApplicationStatusQuery { CandidateId = candidateId };
    var result = await mediator.Send(query);
    return result is not null ? Results.Ok(result) : Results.NotFound();
});

app.MapGet("/jobs", async (IMediator mediator) =>
{
    var query = new GetJobsQuery();
    var jobs = await mediator.Send(query);
    return Results.Ok(jobs);
});

app.MapGraphQL("/graphql");

app.MapDefaultEndpoints();

app.Run();
