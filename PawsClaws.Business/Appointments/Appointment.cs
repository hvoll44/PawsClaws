using PawsClaws.Customers;
using PawsClaws.Pets;

namespace PawsClaws.Appointments;

public class Appointment
{
    public int AppointmentId { get; set; }

    public DateTime Time { get; set; }

    public Customer Customer { get; set; }

    public Pet Pet { get; set; }

    public string Description { get; set; }
}
