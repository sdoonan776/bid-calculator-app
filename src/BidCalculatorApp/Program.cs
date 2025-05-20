using BidCalculatorApp.BidCalculator.Application;
using BidCalculatorApp.BidCalculator.Fees;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IBidCalculator, BidCalculator>();

var assembly = typeof(IFee).Assembly;
var feeTypes = assembly.ExportedTypes.Where(fee =>
                                        fee.IsClass &&
                                        fee.IsPublic &&
                                        !fee.IsAbstract &&
                                        typeof(IFee).IsAssignableFrom(fee)
                                        );

foreach (var feeType in feeTypes)
{
    builder.Services.AddScoped(typeof(IFee), feeType);
}

var origins = builder.Configuration
    .GetSection("Cors:Origins")
    .Get<string[]>(); 

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOrigins", policy =>
    {
        policy.WithOrigins(origins!)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowedOrigins");
app.UseRouting();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();

public partial class Program { }