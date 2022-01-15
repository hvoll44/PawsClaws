using PawsClaws.Appointments;

namespace PawsClaws.Business.Appointments;

public interface IAppointmentService
{
    int CreateAppointment(Appointment appointment);
    List<Appointment> GetAppointmentListAsync();
    int UpdateAppointment(Appointment appointment);
}