using CurrencyConverter.Services;
using CurrencyConverter.Validator;
using FluentValidation.AspNetCore;

string AllowedOrigin = "allowedOrigin";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(option =>
{
    option.AddPolicy(AllowedOrigin, builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CurrencyInputValidator>());

builder.Services.AddSingleton<NumberConverter>();
builder.Services.AddSingleton<DollarConvertor>();
builder.Services.AddScoped<Convertor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(AllowedOrigin);

app.MapControllers();

app.Run();
