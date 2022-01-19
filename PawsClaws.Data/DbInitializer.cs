using PawsClaws.Data.Models;

namespace PawsClaws.Data;

public static class DbInitializer
{
    public static void Initialize(PawsClawsContext context)
    {
        //Look for any customers.
        if (context.Customers.Any())
        {
            return;   // DB has been seeded
        }

        var customers = new Customer[]
        {
            new Customer{FirstName="Carson",LastName="Alexander", Email = "test@test.test", PhoneNumber = "555-555-1234"},
            new Customer{FirstName="Meredith",LastName="Alonso", Email = "test@test.test", PhoneNumber = "555-555-1234"},
            new Customer{FirstName="Arturo",LastName="Anand", Email = "test@test.test", PhoneNumber = "555-555-1234"},
            new Customer{FirstName="Gytis",LastName="Barzdukas", Email = "test@test.test", PhoneNumber = "555-555-1234"},
        };

        context.Customers.AddRange(customers);
        context.SaveChanges();

        var courses = new Pet[]
        {
            new Pet{ PetName = "Blue", CustomerId = 1},
            new Pet{ PetName = "Spot", CustomerId = 2},
            new Pet{ PetName = "Walter", CustomerId = 3},
            new Pet{ PetName = "Sandy", CustomerId = 4},
            new Pet{ PetName = "Rain", CustomerId = 4},
        };

        context.Pets.AddRange(courses);
        context.SaveChanges();

        var appointments = new Appointment[]
        {
            new Appointment{ CustomerId = 1, Time = DateTime.Now, Description="Pet's paw has thorn"},
            new Appointment{ CustomerId = 2, Time = DateTime.Now, Description="Annual checkup"},
        };
        context.Appointments.AddRange(appointments);
        context.SaveChanges();
    }
}