using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository.Abstract;

namespace HospitalManagementSystem.Repository.Concrete
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly HospitalContext _hospitalContext;
        public DoctorRepository(HospitalContext hospitalContext) : base(hospitalContext)
        {
            _hospitalContext = hospitalContext;
        }
    }
}
