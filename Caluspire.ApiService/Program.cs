using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services CQRS, DDD and API operations.
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();

builder.Services.AddMediatR(typeof(Program));  // MédiatR for CQRS

// Add repositories (access data)
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

// Dependency Injection Instances
/*
 * builder.Services.AddTransient<IRequestHandler<SubmitApplicationCommand, bool>, SubmitApplicationHandler>();
 * builder.Services.AddTransient<IRequestHandler<GetApplicationStatusQuery, ApplicationStatusDto>, GetApplicationStatusHandler>(
*/
builder.Services.AddScoped<IRequestHandler<SubmitApplicationCommand, bool>, SubmitApplicationHandler>();
builder.Services.AddScoped<IRequestHandler<GetApplicationStatusQuery, ApplicationStatusDto>, GetApplicationStatusHandler>(

/*
 * builder.Services.AddSingleton<IRequestHandler<SubmitApplicationCommand, bool>, SubmitApplicationHandler>();
 * builder.Services.AddSingleton<IRequestHandler<GetApplicationStatusQuery, ApplicationStatusDto>, GetApplicationStatusHandler>();
*/

// SignalR
builder.Services.AddSignalR();

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

// Configure hubs for SignalR
app.MapHub<JobApplicationHub>("/jobApplicationHub");

app.MapPost("/jobApplications", async (SubmitApplicationCommand command, IMediator mediator) =>
{
    var result = await mediator.Send(command);
    if (result)
    {
        return Results.Ok();
    }
    return Results.BadRequest("Error submitting job application");
});

app.MapGet("/jobApplications/{candidateId}", async (int candidateId, IMediator mediator) =>
{
    var query = new GetApplicationStatusQuery(candidateId);
    var result = await mediator.Send(query);
    return result is not null ? Results.Ok(result) : Results.NotFound();
});

app.MapGet("/jobs", async (IMediator mediator) =>
{
    var query = new GetJobsQuery();
    var jobs = await mediator.Send(query);
    return Results.Ok(jobs);
});


// Add default endpoints
app.MapDefaultEndpoints();

app.Run();
