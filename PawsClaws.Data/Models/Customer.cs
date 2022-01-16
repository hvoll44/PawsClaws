using System.Collections.ObjectModel;

namespace PawsClaws.Data.Models;

public class Customer
{
    public int CustomerId { get; set; }

    public string Email { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public ICollection<Pet> Pets { get; set; }

    public ICollection<Appointment> Appointments { get; set; }

    public Customer()
    {
        Pets = new Collection<Pet>();
        Appointments = new Collection<Appointment>();
    }
}
