using Microsoft.EntityFrameworkCore;
using PawsClaws.Appointments;
using PawsClaws.Data;

namespace PawsClaws.Business.Appointments;

public class AppointmentService : IAppointmentService
{
    private readonly IDbContextFactory<PawsAndClawsContext> _db;

    public AppointmentService(IDbContextFactory<PawsAndClawsContext> db)
    {
        _db = db;
    }

    public async Task<int> CreateAppointmentAsync(AppointmentModel appointment)
    {
        using var context = _db.CreateDbContext();

        await context.Appointments.AddAsync(appointment.ToDto());

        return await context.SaveChangesAsync();
    }

    public async Task<List<AppointmentModel>> GetAppointmentListAsync()
    {
        using var context = _db.CreateDbContext();

        return await context.Appointments
            .Include(a => a.Customer)
            .Select(a => a.ToModel())
            .ToListAsync();
    }

    public async Task<AppointmentModel> GetAppointmentAsync(int appointmentId)
    {
        using var context = _db.CreateDbContext();

        return await Task.Run(() => context.Appointments
            .Include(a => a.Customer)
            .First(a => a.AppointmentId == appointmentId)
            .ToModel());
    }

    public async Task<int> UpdateAppointmentAsync(AppointmentModel appointment)
    {
        using var context = _db.CreateDbContext();

        var appointmentDto = appointment.ToDto();

        var updatedAppointment = context.Appointments
            .Include(a => a.Customer)
            .First(a => a.AppointmentId == appointment.AppointmentId);

        updatedAppointment.Customer.FirstName = appointmentDto.Customer.FirstName;
        updatedAppointment.Customer.LastName = appointmentDto.Customer.LastName;
        updatedAppointment.Customer.Email = appointmentDto.Customer.Email;
        updatedAppointment.Customer.PhoneNumber = appointmentDto.Customer.PhoneNumber;
        updatedAppointment.Description= appointmentDto.Description;

        return await context.SaveChangesAsync();
    }

    public async Task<int> DeleteAppointmentAsync(int appointmentId)
    {
        using var context = _db.CreateDbContext();

        var appointment = context.Appointments.First(a => a.AppointmentId == appointmentId);

        context.Appointments.Remove(appointment);

        return await context.SaveChangesAsync();
    }
}