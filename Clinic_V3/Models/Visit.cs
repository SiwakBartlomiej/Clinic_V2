namespace Clinic_V3.Models;

public class Visit
{
    public DateTime Date { get; set; }
    public Doctor Doctor { get; set; }
    public string Reason { get; set; }
    public string Diagnosis { get; set; }
}