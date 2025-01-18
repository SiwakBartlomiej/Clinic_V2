using Clinic_V3.Models;
using Microsoft.EntityFrameworkCore;
namespace Clinic_V3;

public class AppDbContext : DbContext
{
    public DbSet<Patient> Patient { get; set; }
    public DbSet<Appointment> Appointment { get; set; }
    public DbSet<MedicalPersonnel> MedicalPersonnel { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}