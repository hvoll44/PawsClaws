using Microsoft.AspNetCore.Components;
using PawsClaws.Appointments;
using PawsClaws.Business.Appointments;

namespace PawsClaws.Pages.Appointments;

public sealed partial class AppointmentsListPage
{
    private List<Appointment> _appointments = new List<Appointment>();

    [Inject]
    private IAppointmentService _appointmentService { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await Task.Run(SetAppointmentsAsync);
    }

    private async Task SetAppointmentsAsync()
    {
        _appointments = _appointmentService.GetAppointmentListAsync();
    }
}