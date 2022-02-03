using Microsoft.AspNetCore.Components;
using PawsClaws.Appointments;
using PawsClaws.Business.Appointments;

namespace PawsClaws.Pages.Appointments;

public sealed partial class AppointmentUpdatePage
{
    private AppointmentModel _model = new();

    [Parameter]
    public int AppointmentId { get; set; }

    [Inject]
    private IAppointmentService AppointmentService { get; set; }

    [Inject]
    NavigationManager NavigationManager { get; set; }

    protected override void OnInitialized()
    {
        SetAppointment();
    }

    private void SetAppointment()
    {
        _model = AppointmentService.GetAppointmentAsync(AppointmentId);
    }

    private void OnSubmit()
    {
        AppointmentService.UpdateAppointment(_model);
        NavigationManager.NavigateTo("/appointments");
    }
}