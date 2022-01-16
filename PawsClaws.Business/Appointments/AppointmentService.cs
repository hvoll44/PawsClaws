using PawsClaws.Appointments;
using PawsClaws.Data;

namespace PawsClaws.Business.Appointments;

public class AppointmentService : IAppointmentService
{
    public int CreateAppointment(AppointmentModel appointment)
    {
        using var context = new PawsClawsContext();

        context.Appointments.Add(appointment.ToDto());

        return context.SaveChanges();
    }

    public List<AppointmentModel> GetAppointmentListAsync()
    {
        using var context = new PawsClawsContext();

        return context.Appointments
            .Select(a => a.ToModel())
            .ToList();
    }

    public int UpdateAppointment(AppointmentModel appointment)
    {
        using var context = new PawsClawsContext();

        var appointmentDto = appointment.ToDto();

        var updatedAppointment = context.Appointments.First(a => a.AppointmentId == appointment.AppointmentId);

        updatedAppointment = appointmentDto;

        return context.SaveChanges();
    }

    public int DeleteAppointment(int appointmentId)
    {
        using var context = new PawsClawsContext();

        var appointment = context.Appointments.First(a => a.AppointmentId == appointmentId);

        context.Appointments.Remove(appointment);

        return context.SaveChanges();
    }

    public AppointmentModel GetAppointmentAsync(int appointmentId)
    {
        using var context = new PawsClawsContext();

        return context.Appointments.First(a => a.AppointmentId == appointmentId).ToModel();
    }
}