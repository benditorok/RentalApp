using Microsoft.AspNetCore.Diagnostics;
using RentalApp.Logic.Logic;
using RentalApp.Logic;
using RentalApp.Model;
using RentalApp.Repository.Repository;
using RentalApp.Repository;
using RentalApp.Repository.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RentalAppDbContext>();

builder.Services.AddTransient<IRepository<Car>, CarRepository>();
builder.Services.AddTransient<IRepository<Customer>, CustomerRepository>();
builder.Services.AddTransient<IRepository<Maintenance>, MaintenanceRepository>();
builder.Services.AddTransient<IRepository<Rental>, RentalRepository>();

builder.Services.AddTransient<ICarLogic, CarLogic>();
builder.Services.AddTransient<ICustomerLogic, CustomerLogic>();
builder.Services.AddTransient<IMaintenanceLogic, MaintenanceLogic>();
builder.Services.AddTransient<IRentalLogic, RentalLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features.Get<IExceptionHandlerPathFeature>()!.Error;

    var response = new { Msg = exception.Message };
    await context.Response.WriteAsJsonAsync(response);
}));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
