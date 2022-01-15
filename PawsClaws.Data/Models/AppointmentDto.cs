namespace PawsClaws.Data.Models;

public class AppointmentDto
{
    public int AppointmentDtoId { get; set; }
    
    public CustomerDto Customer { get; set; }
    
    public string Description { get; set; }

    public PetDto Pet { get; set; }
    
    public DateTime Time { get; set; }
}
