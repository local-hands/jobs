using localhands.Jobs.ServiceProvider;
using localhands.Jobs.ServiceProvider.Interface;
using localhands.Jobs.RequestHandler;
using localhands.Jobs.Endpoints;
using localhands.Jobs.Mappers;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using localhands.Jobs.Messaging.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DbServiceProvider>();
builder.Services.AddScoped<IJobsServiceProvider, JobsServiceProvider>();
builder.Services.AddScoped<JobProducer>();
builder.Services.AddScoped<JobRequestHandler>();

// AutoMapper Configuration
builder.Services.AddAutoMapper(typeof(JobProfile));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.MapGet("/", () =>
// {
//     return "Jurgen Klopp - From Doubters to Believers!";
// });

app.MapJobEndpoints();

app.Run();
