
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoDDDNet10.Application.Commands;
using ProjetoDDDNet10.Domain.Interfaces;
using ProjetoDDDNet10.Infrastructure.Data;
using ProjetoDDDNet10.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add Services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("DefaultConnection")));

// DI Repository
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<CreateCustomerCommand>());

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();