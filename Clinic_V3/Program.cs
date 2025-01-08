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
    app.UseSwaggerUI();
    app.UseCors(
        options => options.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader()
    );
}

app.UseHttpsRedirection();

app.MapGet("/appointments", (string dateStart, string dateEnd, string visitType) =>
    {
        var appointments = new List<Appointment>();
        Appointment appointment = new Appointment()
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
        
        appointments.Add(appointment);
        return appointments;
    })
    .WithName("Login")
    .WithOpenApi();

app.Run();