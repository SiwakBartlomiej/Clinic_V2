namespace Clinic_V3.Models;

public class MedicalPersonnel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialization { get; set; }
    public MedicalPersonnelType MedicalPersonnelType { get; set; }

    public MedicalPersonnel()
    {
    }
}
