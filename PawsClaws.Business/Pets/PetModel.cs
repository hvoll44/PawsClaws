using PawsClaws.Customers;

namespace PawsClaws.Pets;

public class PetModel
{
    public int PetId { get; set; }

    public string PetName { get; set; }

    public CustomerModel Customer { get; set; }

    public int CustomerId { get; set; }
}
