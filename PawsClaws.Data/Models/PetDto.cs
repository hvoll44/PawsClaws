namespace PawsClaws.Data.Models;

public class PetDto
{
    public int PetDtoId { get; set; }

    public string PetName { get; set; }

    public CustomerDto Customer { get; set; }

    public int CustomerId { get; set; }
}
