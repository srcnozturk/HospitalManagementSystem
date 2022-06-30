using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repository.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int? id);
    }
}
