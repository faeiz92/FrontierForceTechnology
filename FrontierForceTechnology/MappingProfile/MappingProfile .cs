using AutoMapper;

namespace ProjectB.MappingProfile
{
    using AutoMapper;
    using ProjectA.DTO;
    using ProjectB.DTO;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderHeader, OrderHeaderDTO>()
            .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

            // Mapping for OrderDetail
            CreateMap<OrderDetail, OrderDetailDTO>()
                .ForMember(dest => dest.ConsignorCountryCode, opt => opt.Ignore()) 
                .ForMember(dest => dest.ConsignorCountryName, opt => opt.Ignore());
        }
    }

}
