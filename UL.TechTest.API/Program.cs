using FluentValidation;
using UL.TestTest.Services;
using UL.TestTest.Services.Factorial;
using UL.TestTest.Services.FizzBuzz;
using UL.TestTest.Services.Factorial.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IServiceFactory, ServiceFactory>();
builder.Services.AddTransient<IFizzBuzzService, FizzBuzzService>();
builder.Services.AddTransient<IFactorialService, FactorialService>();

builder.Services.AddValidatorsFromAssemblyContaining<CalculateFactorialValidator>(ServiceLifetime.Transient);

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
