namespace Clinic_V3.Models;

public class Patient
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public char Gender { get; set; }
    public ContactInformation ContactInfo { get; set; }
    public List<Visit> Visits { get; set; }

    public Patient()
    {
        Visits = new List<Visit>();
        ContactInfo = new ContactInformation();
    }
}