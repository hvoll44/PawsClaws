using Microsoft.AspNetCore.Components;
using PawsClaws.Appointments;
using PawsClaws.Business.Appointments;

namespace PawsClaws.Pages.Appointments
{
    public sealed partial class AppointmentUpdatePage
    {
        [Parameter]
        public int AppointmentId { get; set; }

        private AppointmentModel _model = new();

        [Inject]
        private IAppointmentService _appointmentService { get; set; }

        //{
        //    await Task.Run(SetAppointmentAsync);
        //}

        private async Task SetAppointmentAsync()
        {
            _model = _appointmentService.GetAppointmentAsync(AppointmentId);
        }

        private void OnSubmit()
        {
            _appointmentService.UpdateAppointment(_model);
        }
    }
}
