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

    protected override async Task OnInitializedAsync()
    {
        await SetAppointmentAsync();
    }

    private async Task SetAppointmentAsync()
    {
        _model = await AppointmentService.GetAppointmentAsync(AppointmentId);
    }

    private async Task OnSubmitAsync()
    {
        await AppointmentService.UpdateAppointmentAsync(_model);
        NavigationManager.NavigateTo("/appointments");
    }
}