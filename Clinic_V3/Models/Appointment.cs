namespace Clinic_V3.Models;

public class Appointment
{
    public DateTime Date { get; set; }
    public MedicalPersonnel MedicalPersonnel { get; set; }
    public string Reason { get; set; }
    public string Diagnosis { get; set; }
    public string Type { get; set; }
}