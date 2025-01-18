using Clinic_V3;
using Clinic_V3.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

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

app.MapPost("/book-appointment", async (AppDbContext dbContext, int appointmentId, int patientId) => //patch or put?
{
    var appointment = await dbContext.Appointment.SingleOrDefaultAsync(x => x.Id == appointmentId);
    appointment.PatientId = patientId;
    await dbContext.SaveChangesAsync();
});

app.MapPost("/patient", async (AppDbContext dbContext, Patient patient) =>
{
    dbContext.Patient.Add(patient);
    await dbContext.SaveChangesAsync();
});

app.MapGet("/patients/{patient_id}/contact-information", async (AppDbContext dbContext, int patient_id) =>
{
    var patient = await dbContext.Patient.SingleOrDefaultAsync(x => x.Id == patient_id);

    return patient?.ContactInfo;
});

app.MapPut("/patients/{patient_id}/contact-information", async (AppDbContext dbContext, int patient_id, ContactInformation contactInformation) =>
{
    var patient = await dbContext.Patient.SingleOrDefaultAsync(x => x.Id == patient_id);
    patient.ContactInfo = contactInformation;
    
    await dbContext.SaveChangesAsync();
    
    return TypedResults.Ok(patient.ContactInfo);
});

app.MapGet("/patients/{patient_id}/appointments", async (AppDbContext dbContext, int patient_id) =>
{
    var appointments = dbContext.Appointment.Where(x => x.PatientId == patient_id);
    var doc = await dbContext.MedicalPersonnel.SingleOrDefaultAsync(x => x.Id == appointments.ToList()[0].MedicalPersonnelId);
    appointments.ToList()[0].MedicalPersonnel = doc;

    return appointments;
});

app.MapGet("/patients", async (AppDbContext dbContext) =>
{
    var records = await dbContext.Patient.ToListAsync();
    return Results.Ok(records);
});

app.MapGet("/appointments", (AppDbContext dbContext, string dateStart, string dateEnd, string appointmentType) =>
{
    var appointments = dbContext.Appointment;

    return appointments.Where(x => 
        x.Date >= DateTime.Parse(dateStart) && 
        x.Date <= DateTime.Parse(dateEnd) && 
        x.PatientId == null);
});

app.Lifetime.ApplicationStarted.Register(() =>
{
    SeedDatabaseAsync(app).GetAwaiter().GetResult();
});

app.Run();
    
async Task SeedDatabaseAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    if (!dbContext.Patient.Any()) //should be a different condition prob xd
    {
        var medicalPersonnel = new List<MedicalPersonnel>
        {
            new()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                MedicalPersonnelType = MedicalPersonnelType.Doctor,
                Specialization = "Kardiolog",
                Title = "dr"
            },
            new()
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                MedicalPersonnelType = MedicalPersonnelType.Nurse,
                Specialization = "None",
                Title = "mgr"
            }
        };
            
        var appointments = new List<Appointment>
        {
            new()
            {
                Id = 1,
                Date = DateTime.Now.AddDays(-2),
                Type = "Konsultacja kardiologiczna",
                Reason = "Headache",
                Diagnosis = "tmp",
                PatientId = 3,
                MedicalPersonnelId = medicalPersonnel[0].Id
            },
            new()
            {
                Id = 2,
                Date = DateTime.Now.AddDays(-5),
                Type = "Badanie kontrolne",
                Reason = "Badanie diagnostyczne",
                Diagnosis = "Cancer",
                PatientId = 3,
                MedicalPersonnelId = medicalPersonnel[1].Id
            },
            new()
            {
                Id = 3,
                Date = DateTime.Now.AddDays(7),
                Type = "Konsultacja neurologiczna",
                Reason = "Badanie neurologiczna",
                Diagnosis = "Heart attack",
                MedicalPersonnelId = medicalPersonnel[0].Id
            },
            new()
            {
                Id = 4,
                Date = DateTime.Now.AddDays(10),
                Type = "Badanie diagnostyczne",
                Reason = "Badanie diagnostyczne",
                Diagnosis = "Sth",
                MedicalPersonnelId = medicalPersonnel[0].Id
            },
            new()
            {
                Id = 5,
                Date = DateTime.Now.AddDays(14),
                Type = "Konsultacja pediatryczna",
                Reason = "Konsultacja pediatryczna",
                Diagnosis = "Sth",
                PatientId = 3,
                MedicalPersonnelId = medicalPersonnel[1].Id
            }
        };
            
        var patient = new Patient()
        {
            ContactInfo = new ContactInformation()
            {
                Address = new Address()
                {
                    City = "Warszawa",
                    PostalCode = "02-908",
                    Street = "Al. Jana Pawła 2 44",
                },
                Email = "test@test.com",
                Phone = "+48 519 759 878",
            },
            Gender = "Male",
            DateOfBirth = DateTime.Now.AddYears(-20),
            FirstName = "John",
            LastName = "Doe",
            Id = 3
        };
            
        await dbContext.Patient.AddAsync(patient);
        await dbContext.MedicalPersonnel.AddRangeAsync(medicalPersonnel);
        await dbContext.Appointment.AddRangeAsync(appointments);
        await dbContext.SaveChangesAsync();
    }
}
