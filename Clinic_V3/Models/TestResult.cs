namespace Clinic_V3.Models;

public class TestResult
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string FilePath { get; set; }
    public DateTime UploadDate { get; set; }
    public string Comment { get; set; }
}