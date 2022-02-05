using PawsClaws.Appointments;

namespace PawsClaws.Business.Appointments;

public interface IAppointmentService
{
    public Task<int> CreateAppointmentAsync(AppointmentModel appointment);
    public Task<AppointmentModel> GetAppointmentAsync(int appointmentId);
    public Task<List<AppointmentModel>> GetAppointmentListAsync();
    public Task<int> UpdateAppointmentAsync(AppointmentModel appointment);
    public Task<int> DeleteAppointmentAsync(int appointmentId);
}