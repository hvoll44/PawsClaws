using Microsoft.EntityFrameworkCore;
using PawsClaws.Appointments;
using PawsClaws.Data;

namespace PawsClaws.Business.Appointments;

public class AppointmentService : IAppointmentService
{
    private readonly IDbContextFactory<PawsClawsContext> _db;

    public AppointmentService(IDbContextFactory<PawsClawsContext> db)
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
            .Select(a => a.ToModel())
            .ToList();
    }

    public int UpdateAppointment(AppointmentModel appointment)
    {
        using var context = _db.CreateDbContext();

        var appointmentDto = appointment.ToDto();

        var updatedAppointment = context.Appointments.First(a => a.AppointmentId == appointment.AppointmentId);

        updatedAppointment = appointmentDto;

        return context.SaveChanges();
    }

    public int DeleteAppointment(int appointmentId)
    {
        using var context = _db.CreateDbContext();

        var appointment = context.Appointments.First(a => a.AppointmentId == appointmentId);

        context.Appointments.Remove(appointment);

        return context.SaveChanges();
    }

    public AppointmentModel GetAppointmentAsync(int appointmentId)
    {
        using var context = _db.CreateDbContext();

        return context.Appointments.First(a => a.AppointmentId == appointmentId).ToModel();
    }
}