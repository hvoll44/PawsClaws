using PawsClaws.Customers;

namespace PawsClaws.Pets;

public class Pet
{
    public int PetId { get; set; }

    public string PetName { get; set; }

    public Customer Customer { get; set; }

    public int CustomerId { get; set; }
}
