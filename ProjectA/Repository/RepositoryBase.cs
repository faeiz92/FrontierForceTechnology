using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectA.Entitites;
using ProjectA.Persistence;
using ProjectA.Repository;
using Microsoft.EntityFrameworkCore;

namespace ProjectA.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public RepositoryContext _context {  get; set; }

        public RepositoryBase(RepositoryContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }
        public  void  Update(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
            return _context.Set<TEntity>();
        }

        public async Task UpdateTotalWeight(string MawbReference, decimal totalWeight)
        {
            var entity = await _context.Set<TEntity>().FindAsync(MawbReference);
            if (entity != null)
            {

                var propertyInfo = typeof(TEntity).GetProperty("TotalWeight");
                if (propertyInfo != null)
                {
                    if (propertyInfo.PropertyType == typeof(int?) || propertyInfo.PropertyType == typeof(int))
                    {
                       
                        propertyInfo.SetValue(entity, (int?)(totalWeight > 0 ? (int)totalWeight : (int?)null));
                    }
                    else
                    {
                        
                        throw new Exception("TotalWeight property is not of type int or Nullable<int>");
                    }

                    await _context.SaveChangesAsync();
                }


            }
            else
            {
                throw new Exception("Entity not found");
            }
        }
    }
}
