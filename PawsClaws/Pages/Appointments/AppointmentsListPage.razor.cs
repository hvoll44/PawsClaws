using Microsoft.AspNetCore.Components;
using PawsClaws.Appointments;
using PawsClaws.Business.Appointments;

namespace PawsClaws.Pages.Appointments;

public sealed partial class AppointmentsListPage
{
    private List<AppointmentModel> _appointments = new List<AppointmentModel>();

    [Inject]
    private IAppointmentService _appointmentService { get; set; }

    [Inject]
    NavigationManager NavigationManager { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await Task.Run(SetAppointmentsAsync);
    }

    private async Task SetAppointmentsAsync()
    {
        _appointments = _appointmentService.GetAppointmentListAsync();
    }

    private async Task OnDelete(int appointmentId)
    {
        _appointmentService.DeleteAppointment(appointmentId);
    }

    private async Task OnUpdate(int appointmentId)
    {
        NavigationManager.NavigateTo($"appointments/Update-appointment/{appointmentId}");
    }
}