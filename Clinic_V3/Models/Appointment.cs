using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_V3.Models;

public class Appointment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string? Reason { get; set; }
    public string? Diagnosis { get; set; }
    public string Type { get; set; }
    public int MedicalPersonnelId { get; set; }
    [ForeignKey("MedicalPersonnelId")]
    public MedicalPersonnel MedicalPersonnel { get; set; }
    public int? PatientId { get; set; }
    [ForeignKey("PatientId")]
    public Patient Patient { get; set; }

}