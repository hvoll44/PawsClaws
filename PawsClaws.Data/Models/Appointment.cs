namespace PawsClaws.Data.Models;

public class Appointment
{
    public int AppointmentId { get; set; }
    
    public Customer Customer { get; set; }

    public int CustomerId { get; set; }

    public string Description { get; set; }

    public DateTime Time { get; set; }
    
    public Appointment()
    {
        Customer = new Customer();
    }
}
