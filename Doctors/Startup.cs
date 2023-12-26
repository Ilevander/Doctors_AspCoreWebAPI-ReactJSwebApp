using Doctors.Services;
/*AddSingleton:
==============
The service is created once and reused for the entire lifetime of the application.
It is suitable for stateless services or services that have shared, immutable state across all clients.

AddScoped:
==========
The service is created once per request (scoped to the lifetime of the HTTP request).
It is suitable for services that should have a unique instance per HTTP request.

AddTransient:
=============

A new instance is created every time the service is requested.
It is suitable for lightweight, stateless services that are quick to instantiate.

 */
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
 * Choosing Between AddSingleton, AddScoped, and AddTransient:
 * ***********************************************************
Singleton: Use it when the service instance can be shared across the entire application, and its state is not dependent on a specific request or user.

Scoped: Use it when the service instance needs to be created once per request. This is useful for services that require per-request initialization or have per-request state.

Transient: Use it when a new instance of the service is needed every time it is requested. This is suitable for lightweight, stateless services.
 */
namespace Doctors
{
    public class Startup
    {
        //Here we register  all services configuration
        //Register services with the dependency injection (DI) container
        public void ConfigureServices(IServiceCollection services)
        {
            // Doctor Service Configuration
            services.AddScoped<IDoctorService, DoctorService>(); // Assuming DoctorService has per-request state or initialization

            // Appointment Service Configuration
            services.AddScoped<IAppointmentService, AppointmentService>(); // Assuming AppointmentService has per-request state or initialization

            // Booking Service Configuration
            services.AddScoped<IBookingService, BookingService>(); // Assuming BookingService has per-request state or initialization

            // Fees Service Configuration
            services.AddScoped<IFeesService, FeesService>(); // Assuming FeesService has per-request state or initialization

            // Schedule Service Configuration
            services.AddScoped<IScheduleService, ScheduleService>(); // Assuming ScheduleService has per-request state or initialization

            // Clinic Service Configuration
            services.AddScoped<IClinicService, ClinicService>(); // Assuming ClinicService has per-request state or initialization

            // Role Service Configuration
            services.AddScoped<IRoleService, RoleService>(); // Assuming RoleService has per-request state or initialization

            // Permission Service Configuration
            services.AddScoped<IPermissionService, PermissionService>(); // Assuming PermissionService has per-request state or initialization

            // Patient Service Configuration
            services.AddScoped<IPatientService, PatientService>(); // Assuming PatientService has per-request state or initialization

            // User Service Configuration
            services.AddScoped<IUserService, UserService>(); // Assuming UserService has per-request state or initialization

            // Add MVC for API controllers
            services.AddControllers();
        }

    }
}
