using ChuA.SharedKernel.Abstractions;
using ChuA.SharedKernel.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddChuASharedKernel(builder.Configuration);

// Or bind from a custom section:
// builder.Services.AddChuASharedKernel(builder.Configuration, "Platform:SharedKernel");

var app = builder.Build();

app.MapGet("/health/shared-kernel", (IClock clock, ICorrelationIdProvider correlation) => new
{
    timestamp = clock.Now,
    correlation.CorrelationId
});

app.Run();
