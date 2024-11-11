using MinimalAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICalculatorService, CalculatorService>();

var app = builder.Build();

app.MapGet("/add", (int x, int y, ICalculatorService calculatorService) =>
{
    int result = calculatorService.add(x, y);
    return result;
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
