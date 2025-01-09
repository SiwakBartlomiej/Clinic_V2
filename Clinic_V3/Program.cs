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
        options => options.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader() //FIX eventually
    );
}

app.UseHttpsRedirection();

app.MapPost("/book-appointment", (int appointmentId) =>
{
    Console.WriteLine(appointmentId);
});

app.MapGet("/appointments", (string dateStart, string dateEnd, string appointmentType) =>
    {
        var appointments = new List<Appointment>
        {
            new Appointment()
            {
                Id = 1,
                Date = DateTime.Now.AddDays(2),
                Type = "Konsultacja kardiologiczna",
                MedicalPersonnel = new MedicalPersonnel()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    MedicalPersonnelType = MedicalPersonnelType.Doctor,
                    Specialization = "Kardiolog",
                    Title = "dr"
                }
            },
            new Appointment()
            {
                Id = 2,
                Date = DateTime.Now.AddDays(5),
                Type = "Badanie kontrolne",
                MedicalPersonnel = new MedicalPersonnel()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    MedicalPersonnelType = MedicalPersonnelType.Nurse,
                    Specialization = "Pielęgniarstwo",
                    Title = "mgr"
                }
            },
            new Appointment()
            {
                Id = 3,
                Date = DateTime.Now.AddDays(7),
                Type = "Konsultacja neurologiczna",
                MedicalPersonnel = new MedicalPersonnel()
                {
                    Id = 3,
                    FirstName = "Emily",
                    LastName = "Brown",
                    MedicalPersonnelType = MedicalPersonnelType.Doctor,
                    Specialization = "Neurolog",
                    Title = "dr"
                }
            },
            new Appointment()
            {
                Id = 4,
                Date = DateTime.Now.AddDays(10),
                Type = "Badanie diagnostyczne",
                MedicalPersonnel = new MedicalPersonnel()
                {
                    Id = 4,
                    FirstName = "Michael",
                    LastName = "White",
                    MedicalPersonnelType = MedicalPersonnelType.Doctor,
                    Specialization = "Diagnostyka obrazowa",
                    Title = "inż."
                }
            },
            new Appointment()
            {
                Id = 5,
                Date = DateTime.Now.AddDays(14),
                Type = "Konsultacja pediatryczna",
                MedicalPersonnel = new MedicalPersonnel()
                {
                    Id = 5,
                    FirstName = "Sophia",
                    LastName = "Green",
                    MedicalPersonnelType = MedicalPersonnelType.Doctor,
                    Specialization = "Pediatra",
                    Title = "dr"
                }
            }
        };

        return appointments;
    })
    .WithName("Login")
    .WithOpenApi();

app.Run();