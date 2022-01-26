using Microsoft.EntityFrameworkCore;
using PawsClaws.Appointments;
using PawsClaws.Data;

namespace PawsClaws.Business.Appointments;

public class AppointmentService : IAppointmentService
{
    private readonly IDbContextFactory<PawsAndClawsContext> _db;

    public AppointmentService(IDbContextFactory<PawsAndClawsContext> db)
    {
        _db = db;
    }

    public int CreateAppointment(AppointmentModel appointment)
    {
        using var context = _db.CreateDbContext();

        context.Appointments.Add(appointment.ToDto());

        return context.SaveChanges();
    }

    public List<AppointmentModel> GetAppointmentListAsync()
    {
        using var context = _db.CreateDbContext();

        return context.Appointments
            .Include(a => a.Customer)
            .Select(a => a.ToModel())
            .ToList();
    }

    public AppointmentModel GetAppointmentAsync(int appointmentId)
    {
        using var context = _db.CreateDbContext();

        return context.Appointments
            .Include(a => a.Customer)
            .First(a => a.AppointmentId == appointmentId)
            .ToModel();
    }

    public int UpdateAppointment(AppointmentModel appointment)
    {
        using var context = _db.CreateDbContext();

        var appointmentDto = appointment.ToDto();

        var updatedAppointment = context.Appointments
            .Include(a => a.Customer)
            .First(a => a.AppointmentId == appointment.AppointmentId);

        updatedAppointment.Customer.FirstName = appointmentDto.Customer.FirstName;
        updatedAppointment.Customer.LastName = appointmentDto.Customer.LastName;
        updatedAppointment.Customer.Email = appointmentDto.Customer.Email;
        updatedAppointment.Customer.PhoneNumber = appointmentDto.Customer.PhoneNumber;
        updatedAppointment.Description= appointmentDto.Description;

        return context.SaveChanges();
    }

    public int DeleteAppointment(int appointmentId)
    {
        using var context = _db.CreateDbContext();

        var appointment = context.Appointments.First(a => a.AppointmentId == appointmentId);

        context.Appointments.Remove(appointment);

        return context.SaveChanges();
    }
}