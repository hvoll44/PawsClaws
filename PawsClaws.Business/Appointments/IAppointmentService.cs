using PawsClaws.Appointments;

namespace PawsClaws.Business.Appointments;

public interface IAppointmentService
{
    public int CreateAppointment(AppointmentModel appointment);
    public AppointmentModel GetAppointmentAsync(int appointmentId);
    public List<AppointmentModel> GetAppointmentListAsync();
    public int UpdateAppointment(AppointmentModel appointment);
    public int DeleteAppointment(int appointmentId);
}