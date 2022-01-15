using PawsClaws.Appointments;
using PawsClaws.Customers;
using PawsClaws.Data;
using PawsClaws.Data.Models;
using PawsClaws.Pets;

namespace PawsClaws.Business.Appointments;

public class AppointmentService : IAppointmentService
{
    public int CreateAppointment(Appointment appointment)
    {
        using var context = new PawsClawsContext();

        context.Appointments.Add(appointment.ToDto());

        return context.SaveChanges();
    }

    public List<Appointment> GetAppointmentListAsync()
    {
        using var context = new PawsClawsContext();

        return context.Appointments
            .Select(a => a.ToModel())
            .ToList();
    }

    public int UpdateAppointment(Appointment appointment)
    {
        using var context = new PawsClawsContext();

        var appointmentDto = appointment.ToDto();

        var updatedAppointment = context.Appointments.First(a => a.AppointmentDtoId == appointment.AppointmentId);

        updatedAppointment = appointmentDto;

        return context.SaveChanges();
    }

    public int DeleteAppointment(int appointmentId)
    {
        using var context = new PawsClawsContext();

        var appointment = context.Appointments.First(a => a.AppointmentDtoId == appointmentId);

        context.Appointments.Remove(appointment);

        return context.SaveChanges();
    }
}

public static class Mapper
{
    public static AppointmentDto ToDto(this Appointment model) => new AppointmentDto()
    {
        AppointmentDtoId = model.AppointmentId,
        Customer = new CustomerDto()
        {
            FirstName = model.Customer.FirstName,
            LastName = model.Customer.LastName,
            Email = model.Customer.Email,
            PhoneNumber = model.Customer.PhoneNumber,
        },
        Description = model.Description,
        Pet = new PetDto()
        {
            PetName = model.Pet.PetName,
            CustomerId = model.Customer.CustomerId,
        },
        Time = model.Time
    };

    public static Appointment ToModel(this AppointmentDto dto) => new Appointment()
    {
        AppointmentId = dto.AppointmentDtoId,
        Customer = new Customer()
        {
            FirstName = dto.Customer.FirstName,
            LastName = dto.Customer.LastName,
            Email= dto.Customer.Email,
            PhoneNumber= dto.Customer.PhoneNumber,
        },
        Description = dto.Description,
        Pet = new Pet()
        {
            PetName = dto.Pet.PetName,
            CustomerId = dto.Customer.CustomerDtoId,
        },
        Time = dto.Time
    };
}