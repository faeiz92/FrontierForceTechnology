using ProjectA.DTO;
using ProjectA.Entitites;
using ProjectA.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Repository
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext) 
        { }
        
    }
}
