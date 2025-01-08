namespace Clinic_V3.Models;

public class Doctor
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialization { get; set; }
    public ContactInformation ContactInfo { get; set; }
    public List<Patient> Patients { get; set; }

    public Doctor()
    {
        Patients = new List<Patient>();
        ContactInfo = new ContactInformation();
    }
}
