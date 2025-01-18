using Microsoft.EntityFrameworkCore;

namespace Clinic_V3.Models;

[Owned]
public class Address
{
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
}