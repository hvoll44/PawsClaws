using Microsoft.AspNetCore.Components;
using PawsClaws.Appointments;
using PawsClaws.Business.Appointments;

namespace PawsClaws.Pages.Appointments;

public sealed partial class AppointmentCreatePage
{
    private AppointmentModel _model = new();

    [Inject]
    private IAppointmentService AppointmentService { get; set; }

    [Inject]
    NavigationManager NavigationManager { get; set; }

    private async Task OnSubmitAsync()
    {
        await AppointmentService.CreateAppointmentAsync(_model);
        NavigationManager.NavigateTo("/appointments");
    }
}