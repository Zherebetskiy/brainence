using Brainence.Domain.Abstractions;
using Brainence.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brainence.DAL
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly OrdersDbContext dbContext;
        private readonly DbSet<T> dbSet;
        public Repository(OrdersDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
            }
            catch (Exception)
            {
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                dbSet.Remove(await dbSet.FindAsync(id));
            }
            catch (Exception)
            {
            }            
        }

        public async Task Delete()
        {
            try
            {
                await dbSet.ForEachAsync(item => dbSet.Remove(item));
            }
            catch (Exception)
            {
            }            
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await dbSet.ToListAsync();  // _mapper.Map<IEnumerable<NewsDTO>>(documents);
        }

        public async Task Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
