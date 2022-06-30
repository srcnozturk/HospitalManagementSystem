using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository.Abstract;

namespace HospitalManagementSystem.Repository.Concrete
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly HospitalContext _hospitalContext;
        public AppointmentRepository(HospitalContext hospitalContext) : base(hospitalContext)
        {
            _hospitalContext = hospitalContext;
        }
    }
}
