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
    public class OrderHeaderRepository : RepositoryBase<OrderHeader>, IOrderHeaderRepository
    {
        public OrderHeaderRepository(RepositoryContext repositoryContext)
       : base(repositoryContext)
        {

        }

    }
}
