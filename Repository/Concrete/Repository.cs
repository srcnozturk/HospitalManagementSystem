using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repository.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly HospitalContext _hospitalContext;
        public Repository(HospitalContext dbContext)
        {
            _hospitalContext = dbContext;
        }

        public async Task Create(TEntity entity)
        {
            await _hospitalContext.Set<TEntity>().AddAsync(entity);
            await _hospitalContext.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var entity = await GetById((int)id);
            _hospitalContext.Set<TEntity>().Remove(entity);
            await _hospitalContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _hospitalContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _hospitalContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Update(int id, TEntity entity)
        {
            _hospitalContext.Set<TEntity>().Update(entity);
            await _hospitalContext.SaveChangesAsync();
        }
    }
}
