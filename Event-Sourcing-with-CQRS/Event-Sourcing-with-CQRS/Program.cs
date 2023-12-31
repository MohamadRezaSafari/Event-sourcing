using Event_Sourcing_with_CQRS.AuditLog;
using Event_Sourcing_with_CQRS.EventReplay;
using Event_Sourcing_with_CQRS.Infrastructure;
using Event_Sourcing_with_CQRS.Infrastructure.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddMediatR(typeof(Startup));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext")));
builder.Services.AddDbContext<AppReadDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppReadDbContext")));
//builder.Services.AddDbContext<AuditLogDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("AuditLogDbConnection")));


builder.Services.AddScoped<ReplayingEventsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
