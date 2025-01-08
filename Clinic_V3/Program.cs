var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(
        options => options.WithOrigins("http://localhost:5173").AllowAnyMethod()
    );
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", () =>
    {
        return
            "{\n  \"name\": \"John Doe\",\n  \"age\": 30,\n  \"email\": \"johndoe@example.com\",\n  \"isAdmin\": true,\n  \"friends\": [\"Jane\", \"Bob\", \"Alice\"]\n}";
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();