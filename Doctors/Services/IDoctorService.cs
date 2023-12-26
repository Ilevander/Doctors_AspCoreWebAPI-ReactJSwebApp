using Doctors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
//////////////////
//PLEASE READE ME TO UNDERSTAND HOW I WORKS
/*For each Model i've created its interface service
 And each interface implements a class with services
And After we add its Configuration into the Startup.cs class
 */
namespace Doctors.Services
{
    /*Doctors Interface  for its Services*/
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetDoctors();
        Doctor GetDoctorById(int id);
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor updatedDoctor);
        void DeleteDoctor(int id);
        IEnumerable<Doctor> SearchDoctors(string searchTerm);
        void SaveDoctor(Doctor doctor);
        Doctor EditDoctor(int id, Doctor editedDoctor);
    }

    public class DoctorService : IDoctorService
    {
        private readonly List<Doctor> _doctors; 

        public DoctorService()
        {
            // Initialize the list or connect to your database
            _doctors = new List<Doctor>();
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _doctors;
        }

        public Doctor GetDoctorById(int id)
        {
            return _doctors.FirstOrDefault(d => d.DoctorId == id);
        }

        public void AddDoctor(Doctor doctor)
        {
            _doctors.Add(doctor);
        }

        public void UpdateDoctor(Doctor updatedDoctor)
        {
            var existingDoctor = _doctors.FirstOrDefault(d => d.DoctorId == updatedDoctor.DoctorId);
            if (existingDoctor != null)
            {
                // Update the properties of the existing doctor
                existingDoctor.Name = updatedDoctor.Name;
                existingDoctor.Specialist = updatedDoctor.Specialist;
                // Update other properties as needed
            }
        }

        public void DeleteDoctor(int id)
        {
            var doctorToRemove = _doctors.FirstOrDefault(d => d.DoctorId == id);
            if (doctorToRemove != null)
            {
                _doctors.Remove(doctorToRemove);
            }
        }

        public IEnumerable<Doctor> SearchDoctors(string searchTerm)
        {
            return _doctors.Where(d => d.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
        public void SaveDoctor(Doctor doctor)
        {
            if (doctor.DoctorId == 0)
            {
                // If the doctor ID is 0, it's a new doctor, so add it
                AddDoctor(doctor);
            }
            else
            {
                // If the doctor ID is not 0, it's an existing doctor, so update it
                UpdateDoctor(doctor);
            }
        }
        public Doctor EditDoctor(int id, Doctor editedDoctor)
        {
            var existingDoctor = _doctors.FirstOrDefault(d => d.DoctorId == id);
            if (existingDoctor != null)
            {
                // Update the properties of the existing doctor
                existingDoctor.Name = editedDoctor.Name;
                existingDoctor.Specialist = editedDoctor.Specialist;
                // Update other properties as needed

                return existingDoctor;
            }

            return null; // Return null if the doctor with the specified ID is not found
        }
    }

    /*Appointment Interface for its Services*/
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAppointments();
        Appointment GetAppointmentById(int id);
        void AddAppointment(Appointment appointment);
        void UpdateAppointment(Appointment updatedAppointment);
        void DeleteAppointment(int id);
        IEnumerable<Appointment> SearchAppointments(string searchTerm);
        void SaveAppointment(Appointment appointment);
        Appointment EditAppointment(int id, Appointment editedAppointment);
    }
    public class AppointmentService : IAppointmentService
    {
        private readonly List<Appointment> _appointments; // Replace this with your actual data store

        public AppointmentService()
        {
            // Initialize the list or connect to your database
            _appointments = new List<Appointment>();
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _appointments;
        }

        public Appointment GetAppointmentById(int id)
        {
            return _appointments.FirstOrDefault(a => a.AppointmentId == id);
        }

        public void AddAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
        }

        public void UpdateAppointment(Appointment updatedAppointment)
        {
            var existingAppointment = _appointments.FirstOrDefault(a => a.AppointmentId == updatedAppointment.AppointmentId);
            if (existingAppointment != null)
            {
                // Update the properties of the existing appointment
                existingAppointment.Type = updatedAppointment.Type;
                existingAppointment.Date = updatedAppointment.Date;
                // Update other properties as needed
            }
        }

        public void DeleteAppointment(int id)
        {
            var appointmentToRemove = _appointments.FirstOrDefault(a => a.AppointmentId == id);
            if (appointmentToRemove != null)
            {
                _appointments.Remove(appointmentToRemove);
            }
        }

        public IEnumerable<Appointment> SearchAppointments(string searchTerm)
        {
            return _appointments.Where(a => a.Type.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
        public void SaveAppointment(Appointment appointment)
        {
            if (appointment.AppointmentId == 0)
            {
                // If the appointment ID is 0, it's a new appointment, so add it
                AddAppointment(appointment);
            }
            else
            {
                // If the appointment ID is not 0, it's an existing appointment, so update it
                UpdateAppointment(appointment);
            }
        }
        public Appointment EditAppointment(int id, Appointment editedAppointment)
        {
            var existingAppointment = _appointments.FirstOrDefault(a => a.AppointmentId == id);
            if (existingAppointment != null)
            {
                // Update the properties of the existing appointment
                existingAppointment.Type = editedAppointment.Type;
                existingAppointment.Date = editedAppointment.Date;
                // Update other properties as needed

                return existingAppointment;
            }

            return null; // Return null if the appointment with the specified ID is not found
        }
    }
    /*Booking Interface for its Services*/
    public interface IBookingService
    {
        IEnumerable<Booking> GetBookings();
        Booking GetBookingById(int id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking updatedBooking);
        void DeleteBooking(int id);
        IEnumerable<Booking> SearchBookings(string searchTerm);
        void SaveBooking(Booking booking);
        Booking EditBooking(int id, Booking editedBooking);
    }
    public class BookingService : IBookingService
    {
        private readonly List<Booking> _bookings; // Replace this with your actual data store

        public BookingService()
        {
            // Initialize the list or connect to your database
            _bookings = new List<Booking>();
        }

        public IEnumerable<Booking> GetBookings()
        {
            return _bookings;
        }

        public Booking GetBookingById(int id)
        {
            return _bookings.FirstOrDefault(b => b.BookingId == id);
        }

        public void AddBooking(Booking booking)
        {
            _bookings.Add(booking);
        }

        public void UpdateBooking(Booking updatedBooking)
        {
            var existingBooking = _bookings.FirstOrDefault(b => b.BookingId == updatedBooking.BookingId);
            if (existingBooking != null)
            {
                // Update the properties of the existing booking
                existingBooking.Title = updatedBooking.Title;
                existingBooking.Type = updatedBooking.Type;
                existingBooking.AppointmentId = updatedBooking.AppointmentId;
                existingBooking.Date = updatedBooking.Date;
                // Update other properties as needed
            }
        }

        public void DeleteBooking(int id)
        {
            var bookingToRemove = _bookings.FirstOrDefault(b => b.BookingId == id);
            if (bookingToRemove != null)
            {
                _bookings.Remove(bookingToRemove);
            }
        }

        public IEnumerable<Booking> SearchBookings(string searchTerm)
        {
            return _bookings.Where(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
        public void SaveBooking(Booking booking)
        {
            if (booking.BookingId == 0)
            {
                // If the booking ID is 0, it's a new booking, so add it
                AddBooking(booking);
            }
            else
            {
                // If the booking ID is not 0, it's an existing booking, so update it
                UpdateBooking(booking);
            }
        }
        public Booking EditBooking(int id, Booking editedBooking)
        {
            var existingBooking = _bookings.FirstOrDefault(b => b.BookingId == id);
            if (existingBooking != null)
            {
                // Update the properties of the existing booking
                existingBooking.Title = editedBooking.Title;
                existingBooking.Type = editedBooking.Type;
                existingBooking.AppointmentId = editedBooking.AppointmentId;
                existingBooking.Date = editedBooking.Date;
                // Update other properties as needed

                return existingBooking;
            }

            return null; // Return null if the booking with the specified ID is not found
        }
    }
    /*Fees Interface for its Services*/
    public interface IFeesService
    {
        IEnumerable<Fees> GetFees();
        Fees GetFeesById(int id);
        void AddFees(Fees fees);
        void UpdateFees(Fees updatedFees);
        void DeleteFees(int id);
        IEnumerable<Fees> SearchFees(string searchTerm);
        void SaveFees(Fees fees);
        Fees EditFees(int id, Fees editedFees);
    }
    public class FeesService : IFeesService
    {
        private readonly List<Fees> _fees; // Replace this with your actual data store

        public FeesService()
        {
            // Initialize the list or connect to your database
            _fees = new List<Fees>();
        }

        public IEnumerable<Fees> GetFees()
        {
            return _fees;
        }

        public Fees GetFeesById(int id)
        {
            return _fees.FirstOrDefault(f => f.DoctorFeeId == id);
        }

        public void AddFees(Fees fees)
        {
            _fees.Add(fees);
        }

        public void UpdateFees(Fees updatedFees)
        {
            var existingFees = _fees.FirstOrDefault(f => f.DoctorFeeId == updatedFees.DoctorFeeId);
            if (existingFees != null)
            {
                // Update the properties of the existing fees
                existingFees.DoctorFeeAmount = updatedFees.DoctorFeeAmount;
                existingFees.DoctorFeeTotal = updatedFees.DoctorFeeTotal;
                existingFees.DoctorFeePayment = updatedFees.DoctorFeePayment;
                existingFees.DoctorFeeType = updatedFees.DoctorFeeType;
                existingFees.DoctorFeeDescription = updatedFees.DoctorFeeDescription;
                // Update other properties as needed
            }
        }

        public void DeleteFees(int id)
        {
            var feesToRemove = _fees.FirstOrDefault(f => f.DoctorFeeId == id);
            if (feesToRemove != null)
            {
                _fees.Remove(feesToRemove);
            }
        }

       /* //public IEnumerable<Fees> SearchFees(string searchTerm)
        {
            return _fees.Where(f => f.DoctorFeeType.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }*/

        public void SaveFees(Fees fees)
        {
            if (fees.DoctorFeeId == 0)
            {
                // If the fees ID is 0, it's a new fees entry, so add it
                AddFees(fees);
            }
            else
            {
                // If the fees ID is not 0, it's an existing fees entry, so update it
                UpdateFees(fees);
            }
        }

        public Fees EditFees(int id, Fees editedFees)
        {
            var existingFees = _fees.FirstOrDefault(f => f.DoctorFeeId == id);
            if (existingFees != null)
            {
                // Update the properties of the existing fees
                existingFees.DoctorFeeAmount = editedFees.DoctorFeeAmount;
                existingFees.DoctorFeeTotal = editedFees.DoctorFeeTotal;
                existingFees.DoctorFeePayment = editedFees.DoctorFeePayment;
                existingFees.DoctorFeeType = editedFees.DoctorFeeType;
                existingFees.DoctorFeeDescription = editedFees.DoctorFeeDescription;
                // Update other properties as needed

                return existingFees;
            }

            return null; // Return null if the fees entry with the specified ID is not found
        }

        public IEnumerable<Fees> SearchFees(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
    /*Schedule Interface for its Services*/
    public interface IScheduleService
    {
        IEnumerable<Schedule> GetSchedules();
        Schedule GetScheduleById(int id);
        void AddSchedule(Schedule schedule);
        void UpdateSchedule(Schedule updatedSchedule);
        void DeleteSchedule(int id);
        IEnumerable<Schedule> SearchSchedules(string searchTerm);

        void SaveSchedule(Schedule schedule);
        Schedule EditSchedule(int id, Schedule editedSchedule);
    }
    public class ScheduleService : IScheduleService
    {
        private readonly List<Schedule> _schedules; // Replace this with your actual data store

        public ScheduleService()
        {
            // Initialize the list or connect to your database
            _schedules = new List<Schedule>();
        }

        public IEnumerable<Schedule> GetSchedules()
        {
            return _schedules;
        }

        public Schedule GetScheduleById(int id)
        {
            return _schedules.FirstOrDefault(s => s.DoctorScheduleId == id);
        }

        public void AddSchedule(Schedule schedule)
        {
            _schedules.Add(schedule);
        }

        public void UpdateSchedule(Schedule updatedSchedule)
        {
            var existingSchedule = _schedules.FirstOrDefault(s => s.DoctorScheduleId == updatedSchedule.DoctorScheduleId);
            if (existingSchedule != null)
            {
                // Update the properties of the existing schedule
                existingSchedule.DoctorScheduleTime = updatedSchedule.DoctorScheduleTime;
                existingSchedule.DoctorScheduleType = updatedSchedule.DoctorScheduleType;
                existingSchedule.DoctorScheduleDate = updatedSchedule.DoctorScheduleDate;
                existingSchedule.DoctorScheduleDescription = updatedSchedule.DoctorScheduleDescription;
                // Update other properties as needed
            }
        }

        public void DeleteSchedule(int id)
        {
            var scheduleToRemove = _schedules.FirstOrDefault(s => s.DoctorScheduleId == id);
            if (scheduleToRemove != null)
            {
                _schedules.Remove(scheduleToRemove);
            }
        }

        /*public IEnumerable<Schedule> SearchSchedules(string searchTerm)
        {
            return _schedules.Where(s => s.DoctorScheduleType.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }*/

        public void SaveSchedule(Schedule schedule)
        {
            if (schedule.DoctorScheduleId == 0)
            {
                // If the schedule ID is 0, it's a new schedule entry, so add it
                AddSchedule(schedule);
            }
            else
            {
                // If the schedule ID is not 0, it's an existing schedule entry, so update it
                UpdateSchedule(schedule);
            }
        }

        public Schedule EditSchedule(int id, Schedule editedSchedule)
        {
            var existingSchedule = _schedules.FirstOrDefault(s => s.DoctorScheduleId == id);
            if (existingSchedule != null)
            {
                // Update the properties of the existing schedule
                existingSchedule.DoctorScheduleTime = editedSchedule.DoctorScheduleTime;
                existingSchedule.DoctorScheduleType = editedSchedule.DoctorScheduleType;
                existingSchedule.DoctorScheduleDate = editedSchedule.DoctorScheduleDate;
                existingSchedule.DoctorScheduleDescription = editedSchedule.DoctorScheduleDescription;
                // Update other properties as needed

                return existingSchedule;
            }

            return null; // Return null if the schedule entry with the specified ID is not found
        }

        public IEnumerable<Schedule> SearchSchedules(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }

    /*Clinic Interface*/
    public interface IClinicService
    {
        IEnumerable<Clinic> GetClinics();
        Clinic GetClinicById(int id);
        void AddClinic(Clinic clinic);
        void UpdateClinic(Clinic updatedClinic);
        void DeleteClinic(int id);
        IEnumerable<Clinic> SearchClinics(string searchTerm);

        void SaveClinic(Clinic clinic);
        Clinic EditClinic(int id, Clinic editedClinic);
    }
    public class ClinicService : IClinicService
    {
        private readonly List<Clinic> _clinics; // Replace this with your actual data store

        public ClinicService()
        {
            // Initialize the list or connect to your database
            _clinics = new List<Clinic>();
        }

        public IEnumerable<Clinic> GetClinics()
        {
            return _clinics;
        }

        public Clinic GetClinicById(int id)
        {
            return _clinics.FirstOrDefault(c => c.ClinicId == id);
        }

        public void AddClinic(Clinic clinic)
        {
            _clinics.Add(clinic);
        }

        public void UpdateClinic(Clinic updatedClinic)
        {
            var existingClinic = _clinics.FirstOrDefault(c => c.ClinicId == updatedClinic.ClinicId);
            if (existingClinic != null)
            {
                // Update the properties of the existing clinic
                existingClinic.ClinicName = updatedClinic.ClinicName;
                existingClinic.ClinicPlace = updatedClinic.ClinicPlace;
                existingClinic.ClinicType = updatedClinic.ClinicType;
                existingClinic.ClinicDescription = updatedClinic.ClinicDescription;
                // Update other properties as needed
            }
        }

        public void DeleteClinic(int id)
        {
            var clinicToRemove = _clinics.FirstOrDefault(c => c.ClinicId == id);
            if (clinicToRemove != null)
            {
                _clinics.Remove(clinicToRemove);
            }
        }

       /* public IEnumerable<Clinic> SearchClinics(string searchTerm)
        {
            return _clinics.Where(c => c.ClinicName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }*/

        public void SaveClinic(Clinic clinic)
        {
            if (clinic.ClinicId == 0)
            {
                // If the clinic ID is 0, it's a new clinic entry, so add it
                AddClinic(clinic);
            }
            else
            {
                // If the clinic ID is not 0, it's an existing clinic entry, so update it
                UpdateClinic(clinic);
            }
        }

        public Clinic EditClinic(int id, Clinic editedClinic)
        {
            var existingClinic = _clinics.FirstOrDefault(c => c.ClinicId == id);
            if (existingClinic != null)
            {
                // Update the properties of the existing clinic
                existingClinic.ClinicName = editedClinic.ClinicName;
                existingClinic.ClinicPlace = editedClinic.ClinicPlace;
                existingClinic.ClinicType = editedClinic.ClinicType;
                existingClinic.ClinicDescription = editedClinic.ClinicDescription;
                // Update other properties as needed

                return existingClinic;
            }

            return null; // Return null if the clinic entry with the specified ID is not found
        }

        public IEnumerable<Clinic> SearchClinics(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
    /*Permission Interface*/
    public interface IPermissionService
    {
        IEnumerable<Permission> GetPermissions();
        Permission GetPermissionById(int id);
        void AddPermission(Permission permission);
        void UpdatePermission(Permission updatedPermission);
        void DeletePermission(int id);
        IEnumerable<Permission> SearchPermissions(string searchTerm);

        void SavePermission(Permission permission);
        Permission EditPermission(int id, Permission editedPermission);
    }
    public class PermissionService : IPermissionService
    {
        private readonly List<Permission> _permissions; // Replace this with your actual data store

        public PermissionService()
        {
            // Initialize the list or connect to your database
            _permissions = new List<Permission>();
        }

        public IEnumerable<Permission> GetPermissions()
        {
            return _permissions;
        }

        public Permission GetPermissionById(int id)
        {
            return _permissions.FirstOrDefault(p => p.Id == id);
        }

        public void AddPermission(Permission permission)
        {
            _permissions.Add(permission);
        }

        public void UpdatePermission(Permission updatedPermission)
        {
            var existingPermission = _permissions.FirstOrDefault(p => p.Id == updatedPermission.Id);
            if (existingPermission != null)
            {
                // Update the properties of the existing permission
                existingPermission.RoleId = updatedPermission.RoleId;
                existingPermission.Title = updatedPermission.Title;
                existingPermission.Module = updatedPermission.Module;
                existingPermission.Description = updatedPermission.Description;
                // Update other properties as needed
            }
        }

        public void DeletePermission(int id)
        {
            var permissionToRemove = _permissions.FirstOrDefault(p => p.Id == id);
            if (permissionToRemove != null)
            {
                _permissions.Remove(permissionToRemove);
            }
        }

        public IEnumerable<Permission> SearchPermissions(string searchTerm)
        {
            return _permissions.Where(p => p.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        public void SavePermission(Permission permission)
        {
            if (permission.Id == 0)
            {
                // If the permission ID is 0, it's a new permission entry, so add it
                AddPermission(permission);
            }
            else
            {
                // If the permission ID is not 0, it's an existing permission entry, so update it
                UpdatePermission(permission);
            }
        }

        public Permission EditPermission(int id, Permission editedPermission)
        {
            var existingPermission = _permissions.FirstOrDefault(p => p.Id == id);
            if (existingPermission != null)
            {
                // Update the properties of the existing permission
                existingPermission.RoleId = editedPermission.RoleId;
                existingPermission.Title = editedPermission.Title;
                existingPermission.Module = editedPermission.Module;
                existingPermission.Description = editedPermission.Description;
                // Update other properties as needed

                return existingPermission;
            }

            return null; // Return null if the permission entry with the specified ID is not found
        }
    }
    /*Patient Interface  for its Services*/
    public interface IPatientService
    {
        IEnumerable<Patient> GetPatients();
        Patient GetPatientById(int id);
        void AddPatient(Patient patient);
        void UpdatePatient(Patient updatedPatient);
        void DeletePatient(int id);
        IEnumerable<Patient> SearchPatients(string searchTerm);

        void SavePatient(Patient patient);
        Patient EditPatient(int id, Patient editedPatient);
    }
    public class PatientService : IPatientService
    {
        private readonly List<Patient> _patients; // Replace this with your actual data store

        public PatientService()
        {
            // Initialize the list or connect to your database
            _patients = new List<Patient>();
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _patients;
        }

        public Patient GetPatientById(int id)
        {
            return _patients.FirstOrDefault(p => p.Id == id);
        }

        public void AddPatient(Patient patient)
        {
            _patients.Add(patient);
        }

        public void UpdatePatient(Patient updatedPatient)
        {
            var existingPatient = _patients.FirstOrDefault(p => p.Id == updatedPatient.Id);
            if (existingPatient != null)
            {
                // Update the properties of the existing patient
                existingPatient.Name = updatedPatient.Name;
                existingPatient.Mobile = updatedPatient.Mobile;
                existingPatient.Address = updatedPatient.Address;
                existingPatient.Email = updatedPatient.Email;
                existingPatient.Password = updatedPatient.Password;
                existingPatient.Username = updatedPatient.Username;
                // Update other properties as needed
            }
        }

        public void DeletePatient(int id)
        {
            var patientToRemove = _patients.FirstOrDefault(p => p.Id == id);
            if (patientToRemove != null)
            {
                _patients.Remove(patientToRemove);
            }
        }

        public IEnumerable<Patient> SearchPatients(string searchTerm)
        {
            return _patients.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        public void SavePatient(Patient patient)
        {
            if (patient.Id == 0)
            {
                // If the patient ID is 0, it's a new patient entry, so add it
                AddPatient(patient);
            }
            else
            {
                // If the patient ID is not 0, it's an existing patient entry, so update it
                UpdatePatient(patient);
            }
        }

        public Patient EditPatient(int id, Patient editedPatient)
        {
            var existingPatient = _patients.FirstOrDefault(p => p.Id == id);
            if (existingPatient != null)
            {
                // Update the properties of the existing patient
                existingPatient.Name = editedPatient.Name;
                existingPatient.Mobile = editedPatient.Mobile;
                existingPatient.Address = editedPatient.Address;
                existingPatient.Email = editedPatient.Email;
                existingPatient.Password = editedPatient.Password;
                existingPatient.Username = editedPatient.Username;
                // Update other properties as needed

                return existingPatient;
            }

            return null; // Return null if the patient entry with the specified ID is not found
        }
    }
    /*Role Interface  for its Services*/
    public interface IRoleService
    {
        IEnumerable<Role> GetRoles();
        Role GetRoleById(int id);
        void AddRole(Role role);
        void UpdateRole(Role updatedRole);
        void DeleteRole(int id);
        IEnumerable<Role> SearchRoles(string searchTerm);

        void SaveRole(Role role);
        Role EditRole(int id, Role editedRole);
    }

    public class RoleService : IRoleService
    {
        private readonly List<Role> _roles; // Replace this with your actual data store

        public RoleService()
        {
            // Initialize the list or connect to your database
            _roles = new List<Role>();
        }

        public IEnumerable<Role> GetRoles()
        {
            return _roles;
        }

        public Role GetRoleById(int id)
        {
            return _roles.FirstOrDefault(r => r.Id == id);
        }

        public void AddRole(Role role)
        {
            _roles.Add(role);
        }

        public void UpdateRole(Role updatedRole)
        {
            var existingRole = _roles.FirstOrDefault(r => r.Id == updatedRole.Id);
            if (existingRole != null)
            {
                // Update the properties of the existing role
                existingRole.Title = updatedRole.Title;
                existingRole.Description = updatedRole.Description;
                // Update other properties as needed
            }
        }

        public void DeleteRole(int id)
        {
            var roleToRemove = _roles.FirstOrDefault(r => r.Id == id);
            if (roleToRemove != null)
            {
                _roles.Remove(roleToRemove);
            }
        }

        public IEnumerable<Role> SearchRoles(string searchTerm)
        {
            return _roles.Where(r => r.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        public void SaveRole(Role role)
        {
            if (role.Id == 0)
            {
                // If the role ID is 0, it's a new role entry, so add it
                AddRole(role);
            }
            else
            {
                // If the role ID is not 0, it's an existing role entry, so update it
                UpdateRole(role);
            }
        }

        public Role EditRole(int id, Role editedRole)
        {
            var existingRole = _roles.FirstOrDefault(r => r.Id == id);
            if (existingRole != null)
            {
                // Update the properties of the existing role
                existingRole.Title = editedRole.Title;
                existingRole.Description = editedRole.Description;
                // Update other properties as needed

                return existingRole;
            }

            return null; // Return null if the role entry with the specified ID is not found
        }
    }
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User updatedUser);
        void DeleteUser(int id);
        IEnumerable<User> SearchUsers(string searchTerm);

        void SaveUser(User user);
        User EditUser(int id, User editedUser);
    }
    /*User Interface  for its Services*/
    public class UserService : IUserService
    {
        private readonly List<User> _users; // Replace this with your actual data store

        public UserService()
        {
            // Initialize the list or connect to your database
            _users = new List<User>();
        }

        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void UpdateUser(User updatedUser)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (existingUser != null)
            {
                // Update the properties of the existing user
                existingUser.RoleId = updatedUser.RoleId;
                existingUser.Name = updatedUser.Name;
                existingUser.Email = updatedUser.Email;
                existingUser.Date = updatedUser.Date;
                existingUser.Address = updatedUser.Address;
                // Update other properties as needed
            }
        }

        public void DeleteUser(int id)
        {
            var userToRemove = _users.FirstOrDefault(u => u.Id == id);
            if (userToRemove != null)
            {
                _users.Remove(userToRemove);
            }
        }

        public IEnumerable<User> SearchUsers(string searchTerm)
        {
            return _users.Where(u => u.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        public void SaveUser(User user)
        {
            if (user.Id == 0)
            {
                // If the user ID is 0, it's a new user entry, so add it
                AddUser(user);
            }
            else
            {
                // If the user ID is not 0, it's an existing user entry, so update it
                UpdateUser(user);
            }
        }

        public User EditUser(int id, User editedUser)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser != null)
            {
                // Update the properties of the existing user
                existingUser.RoleId = editedUser.RoleId;
                existingUser.Name = editedUser.Name;
                existingUser.Email = editedUser.Email;
                existingUser.Date = editedUser.Date;
                existingUser.Address = editedUser.Address;
                // Update other properties as needed

                return existingUser;
            }

            return null; // Return null if the user entry with the specified ID is not found
        }
    }

}










