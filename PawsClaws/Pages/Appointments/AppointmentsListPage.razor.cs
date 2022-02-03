using Microsoft.AspNetCore.Components;
using PawsClaws.Appointments;
using PawsClaws.Business.Appointments;

namespace PawsClaws.Pages.Appointments;

public sealed partial class AppointmentsListPage
{
    private List<AppointmentModel> _appointments = new List<AppointmentModel>();

    [Inject]
    private IAppointmentService AppointmentService { get; set; }

    [Inject]
    NavigationManager NavigationManager { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await Task.Run(SetAppointmentsAsync);
    }

    private async Task SetAppointmentsAsync()
    {
        _appointments = AppointmentService.GetAppointmentListAsync();
    }

    private void OnDelete(int appointmentId)
    {
        AppointmentService.DeleteAppointment(appointmentId);
        NavigationManager.NavigateTo("/appointments", forceLoad: true);
    }

    private async Task OnUpdate(int appointmentId)
    {
        NavigationManager.NavigateTo($"appointments/Update-appointment/{appointmentId}");
    }
}