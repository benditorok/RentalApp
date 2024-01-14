using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using RentalApp.Logic;
using RentalApp.Logic.Logic;
using RentalApp.Model;
using RentalApp.Repository;
using RentalApp.Repository.Context;
using RentalApp.Repository.Repository;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Add Database Contexts
builder.Services.AddDbContext<RentalAppDbContext>();
builder.Services.AddDbContext<RentalAppIdentityDbContext>();

// Add repositories
builder.Services.AddTransient<IRepository<Car>, CarRepository>();
builder.Services.AddTransient<IRepository<Customer>, CustomerRepository>();
builder.Services.AddTransient<IRepository<Maintenance>, MaintenanceRepository>();
builder.Services.AddTransient<IRepository<Rental>, RentalRepository>();

// Add logics
builder.Services.AddTransient<ICarLogic, CarLogic>();
builder.Services.AddTransient<ICustomerLogic, CustomerLogic>();
builder.Services.AddTransient<IMaintenanceLogic, MaintenanceLogic>();
builder.Services.AddTransient<IRentalLogic, RentalLogic>();

// Authorization
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<RentalAppIdentityDbContext>();

// Build
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

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

// Disable the registration page
app.MapGet("/register", context => Task.Factory.StartNew(() => context.Response.Redirect("/login", true, true)));
app.MapPost("/register", context => Task.Factory.StartNew(() => context.Response.Redirect("/login", true, true)));

app.MapControllers();

app.Run();
