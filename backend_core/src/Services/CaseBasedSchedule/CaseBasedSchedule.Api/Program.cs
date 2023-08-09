
using CaseBasedSchedule.Application.Contracts;
using CaseBasedSchedule.Application.Models;
using CaseBasedSchedule.Application.Services;
using CaseBasedSchedule.Domain.Entities;
using CaseBasedSchedule.Domain.Fcatories;
using CaseBasedSchedule.Infrastructure.DependencyInjection;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterEFCore(builder.Configuration.GetConnectionString("DefaultConnection"));
//sessie=> addscoped, bij opstarten singleton en transient bij iedere request
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IPractitionerService,PractitionerService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddScoped<AppointmentModel>();
builder.Services.AddScoped<AppointmentModel>();

builder.Services.AddScoped<AppointmentRequest>();
builder.Services.AddScoped<PractionerRequest>();

// factories
builder.Services.AddSingleton<IPractitionerFactory, Practitioner.PractitionerFactory>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true));
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
