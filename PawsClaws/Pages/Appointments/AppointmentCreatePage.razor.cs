using Microsoft.AspNetCore.Components;
using PawsClaws.Appointments;
using PawsClaws.Business.Appointments;

namespace PawsClaws.Pages.Appointments;

public sealed partial class AppointmentCreatePage
{
    private AppointmentModel _model = new();

    [Inject]
    private IAppointmentService _appointmentService { get; set; }

    private void OnSubmit()
    {
        _appointmentService.CreateAppointment(_model);
    }
}