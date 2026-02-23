using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoDDDNet10.Application.Commands;
using ProjetoDDDNet10.Application.Common.Behaviors;
using ProjetoDDDNet10.Application.Validator;
using ProjetoDDDNet10.Domain.Interfaces;
using ProjetoDDDNet10.Infrastructure.Data;
using ProjetoDDDNet10.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerValidator).Assembly)); 

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).Assembly));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));
var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();