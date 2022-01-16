using PawsClaws.Appointments;
using PawsClaws.Customers;
using PawsClaws.Data.Models;
using PawsClaws.Pets;

namespace PawsClaws.Business.Appointments;

public static class AppointmentMapper
{
    public static Appointment ToDto(this AppointmentModel model) => new Appointment()
    {
        AppointmentId = model.AppointmentId,
        Customer = new Customer()
        {
            FirstName = model.Customer.FirstName,
            LastName = model.Customer.LastName,
            Email = model.Customer.Email,
            PhoneNumber = model.Customer.PhoneNumber,
        },
        Description = model.Description,
        Time = model.Time
    };

    public static AppointmentModel ToModel(this Appointment dto) => new AppointmentModel()
    {
        AppointmentId = dto.AppointmentId,
        Customer = new CustomerModel()
        {
            FirstName = dto.Customer.FirstName,
            LastName = dto.Customer.LastName,
            Email= dto.Customer.Email,
            PhoneNumber= dto.Customer.PhoneNumber,
        },
        Description = dto.Description,
        Pet = new PetModel()
        {
            PetName = dto.Customer.Pets.First().PetName,
            CustomerId = dto.Customer.CustomerId,
        },
        Time = dto.Time
    };
}