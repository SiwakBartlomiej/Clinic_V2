using Microsoft.EntityFrameworkCore;

namespace Clinic_V3.Models;

[Owned]
public class ContactInformation
{
    public Address Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public ContactInformation() { }
}