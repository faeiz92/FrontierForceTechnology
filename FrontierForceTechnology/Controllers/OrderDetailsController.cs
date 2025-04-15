
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectA.DTO;
using ProjectA.Persistence;
using ProjectB.DTO;
using AutoMapper;
using System.Diagnostics.Metrics;
using ProjectB.Utilities;
using System.Text.Json;

namespace ProjectB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly ILogger<OrderDetailsController> _logger;
        private readonly FilePathService _filePathService;

        private IRepositoryWrapper _repository;
        //private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public OrderDetailsController(IRepositoryWrapper repository, IMapper mapper, FilePathService filePathService)
        {
            _repository = repository;
            _mapper = mapper;
            _filePathService = filePathService;
            // _logger = logger;
        }

        [HttpGet]
        [Route("GetOrderDetails")]
        public async Task<List<OrderHeaderDTO>> GetOrderHeadersWithDetails()
        {
            var orderHeadersWithDetails = _repository.OrderHeader
                                            .GetAllQueryable()
                                            .Include(x => x.OrderDetails)
                                            .ToList()
                                            .Where(x => x.OrderDetails.Any(od => od.MawbReference == x.MawbReference))  // Filter in memory
                                            .ToList();

            
            int getTotalWeight = 0;
            string mawbId = string.Empty;

            foreach (var orderHeader in orderHeadersWithDetails)
            {
                mawbId = orderHeader.MawbReference;
                foreach (var orderDetail in orderHeader.OrderDetails)
                {

                    getTotalWeight += Convert.ToInt32(orderDetail.Weight??0);
                }
            }

           await  _repository.OrderHeader.UpdateTotalWeight(mawbId, getTotalWeight);
           _repository.SaveChanges();

            var orderHeadersWithDetails2 = _repository.OrderHeader
                                            .GetAllQueryable()
                                            .Include(x => x.OrderDetails)
                                            .ToList()
                                            .Where(x => x.OrderDetails.Any(od => od.MawbReference == x.MawbReference))  // Filter in memory
                                            .ToList();

            var orderHeaderDTOs = _mapper.Map<List<OrderHeaderDTO>>(orderHeadersWithDetails2);

            var countries = _filePathService.GetCountriesFromJson();

            foreach (var orderHeader in orderHeaderDTOs)
            {
                foreach (var orderDetail in orderHeader.OrderDetails)
                {

                    var country = countries.FirstOrDefault(c => c.FFCountrySID == orderDetail.ConsignorCountrySID);
                    if (country != null)
                    {
                        orderDetail.ConsignorCountryCode = country.CountryCode;
                        orderDetail.ConsignorCountryName = country.CountryName;
                    }
                }
            }
            return orderHeaderDTOs;
        }

    }
}
