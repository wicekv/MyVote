using MyVote.Infrastructure;
using MyVote.Application;
using MyVote.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCore()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseInfrastructure();
app.Run();
