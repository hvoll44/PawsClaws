using PawsClaws.Data.Models;

namespace PawsClaws.Data;

public static class DbInitializer
{
    public static void Initialize(PawsClawsContext context)
    {
        // Look for any customers.
        if (context.Customers.Any())
        {
            return;   // DB has been seeded
        }

        var customers = new CustomerDto[]
        {
            new CustomerDto{FirstName="Carson",LastName="Alexander", Email = "test@test.test", PhoneNumber = "555-555-1234"},
            new CustomerDto{FirstName="Meredith",LastName="Alonso", Email = "test@test.test", PhoneNumber = "555-555-1234"},
            new CustomerDto{FirstName="Arturo",LastName="Anand", Email = "test@test.test", PhoneNumber = "555-555-1234"},
            new CustomerDto{FirstName="Gytis",LastName="Barzdukas", Email = "test@test.test", PhoneNumber = "555-555-1234"},
        };

        context.Customers.AddRange(customers);
        context.SaveChanges();

        var courses = new PetDto[]
        {
            new PetDto{ PetName = "Blue", CustomerId = 1},
            new PetDto{ PetName = "Spot", CustomerId = 1},
            new PetDto{ PetName = "Walter", CustomerId = 3},
            new PetDto{ PetName = "Sandy", CustomerId = 4},
            new PetDto{ PetName = "Rain", CustomerId = 5},
        };

        context.Pets.AddRange(courses);
        context.SaveChanges();        
    }
}