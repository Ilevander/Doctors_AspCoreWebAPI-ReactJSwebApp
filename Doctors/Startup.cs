using Doctors.Services;

namespace Doctors
{
    public class Startup
    {
        //Here we register  all services configuration
        public void ConfigureServices(IServiceCollection services)
        {
            //Doctor Service Configuration
            services.AddSingleton<IDoctorService, DoctorService>();
            //Appointment Service Configuration
            services.AddSingleton<IAppointmentService, AppointmentService>();
        }

    }
}
