using Microsoft.EntityFrameworkCore;
using weatherForecast.Domain.Entities;
using weatherForecast.Domain.Repository;
using weatherForecast.Infrastructure.Data;

namespace weatherForecast.Infrastructure.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext applicationDb;

        public BaseRepository(ApplicationDbContext insuranceDb)
        {
            applicationDb = insuranceDb;
        }

        public async Task<T> AddAsync(T entity)
        {
            await applicationDb.Set<T>().AddAsync(entity);
            await applicationDb.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> AddAsync(List<T> entity)
        {
            await applicationDb.AddRangeAsync(entity);
            await applicationDb.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            applicationDb.Set<T>().Remove(entity);
            await applicationDb.SaveChangesAsync();
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await applicationDb.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await applicationDb.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            applicationDb.Entry(entity).State = EntityState.Modified;
            try
            {
                await applicationDb.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

    }
}
