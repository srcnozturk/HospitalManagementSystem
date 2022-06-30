using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository.Abstract;

namespace HospitalManagementSystem.Repository.Concrete
{
    public class PatientRepository :Repository<Patient>, IPatientRepository
    {
        private readonly HospitalContext _hospitalContext;
        public PatientRepository(HospitalContext hospitalContext) : base(hospitalContext)
        {
            _hospitalContext = hospitalContext;
        }
    }
}
