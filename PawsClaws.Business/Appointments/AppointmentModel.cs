using PawsClaws.Customers;
using PawsClaws.Pets;

namespace PawsClaws.Appointments;

public class AppointmentModel
{
    public int AppointmentId { get; set; }

    public DateTime Time { get; set; } = DateTime.Now;

    public CustomerModel Customer { get; set; } = new CustomerModel();

    public PetModel Pet { get; set; } = new PetModel();

    public string Description { get; set; }
}
