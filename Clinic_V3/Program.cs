using Clinic_V3;
using Clinic_V3.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseCors(
        options => options.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader()
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

app.MapPost("/login", (string dateStart, string dateEnd) =>
    {
        Visit visit = new Visit()
        {
            Date = DateTime.Now.AddDays(2),
            MedicalPersonnel = new MedicalPersonnel()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                MedicalPersonnelType = MedicalPersonnelType.Doctor,
                Specialization = "Kardiolog",
                Title = "dr"
            }
        };
        return visit;
    })
    .WithName("Login")
    .WithOpenApi();

app.Run();