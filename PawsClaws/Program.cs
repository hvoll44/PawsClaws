using Microsoft.EntityFrameworkCore;
using PawsClaws.Business.Appointments;
using PawsClaws.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddDbContextFactory<PawsClawsContext>((provider, options) =>
{
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PawsClaws;Integrated Security=True;Connect Timeout=60;Encrypt=False;ApplicationIntent=ReadWrite;");
});

builder.Services.AddSqlServer<PawsClawsContext>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PawsClaws;Integrated Security=True;Connect Timeout=60;Encrypt=False;ApplicationIntent=ReadWrite;");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();