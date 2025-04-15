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
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _context;
        private IOrderHeaderRepository _orderHeaderRepository;
        private IOrderDetailRepository _orderDetailRepository;

        public RepositoryWrapper(RepositoryContext context)
        {
            _context = context;
        }

        public IOrderHeaderRepository OrderHeader
        {

            get
            {
                if (_orderHeaderRepository == null)
                    _orderHeaderRepository = new OrderHeaderRepository(_context);

                return _orderHeaderRepository;
            }

            /*set
            {
                _userRepository = value;
            }*/
        }
        public IOrderDetailRepository OrderDetail
        {
            get
            {
                if( _orderDetailRepository == null)
                    _orderDetailRepository = new OrderDetailRepository(_context);

                return _orderDetailRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
