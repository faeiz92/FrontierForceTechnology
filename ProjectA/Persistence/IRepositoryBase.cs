using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Persistence
{
    public interface IRepositoryBase<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        IQueryable<TEntity> GetAllQueryable();
        void Update(TEntity entity);
        Task UpdateTotalWeight(string MawbReference, decimal totalWeight);
    }
}
