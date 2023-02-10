using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pizzeriaserver.Application.Common.Behaviors;
using pizzeriaserver.Application.Common.Interfaces;
using pizzeriaserver.Data;
using pizzeriaserver.Data.Services;
using pizzeriaserver.Middleware;
using pizzeriaserver.Repositories;
using System.Reflection;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAllOrigins", 
//        builder =>
//        {
//            builder
//            .AllowAnyOrigin()
//            .AllowAnyHeader()
//            .AllowAnyMethod();
//        });
//});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("CorsPolicy",
//        builder => builder.WithOrigins("http://localhost:3000/")
//        .AllowAnyMethod()
//        .AllowAnyHeader()
//        .AllowCredentials());
//});



builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IDateTime, DateTimeService>();
builder.Services.AddDbContext <ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();
builder.Services.AddScoped<IToppingRepository, ToppingRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddControllers()
    .AddFluentValidation(options =>
    {
        // Validate child properties and root collection elements
        options.ImplicitlyValidateChildProperties = true;
        options.ImplicitlyValidateRootCollectionElements = true;

        // Automatic registration of validators in assembly
        options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<CustomExceptionMiddleware>();

app.MapControllers();

app.Run();
