using PawsClaws.Customers;
using PawsClaws.Pets;

namespace PawsClaws.Appointments;

public class AppointmentModel
{
    public int AppointmentId { get; set; }

    public DateTime Time { get; set; }

    public CustomerModel Customer { get; set; }

    public PetModel Pet { get; set; }

    public string Description { get; set; }
}
