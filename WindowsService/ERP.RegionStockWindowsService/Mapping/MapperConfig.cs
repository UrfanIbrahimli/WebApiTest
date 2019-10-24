using AutoMapper;
using ERP.OutcomeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.RegionStockWindowsService.Mapping
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;
            CreateMap<DS_Outcome, Entities.DS_IncomePrice>().
                ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID)).
                ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate)).
                ForMember(dest => dest.ExternalDocDate, opt => opt.MapFrom(src => src.ExternalDocDate)).
                ForMember(dest => dest.OperationalDay, opt => opt.MapFrom(src => src.ExternalDocDate)).
                ForMember(dest => dest.DS_IncomePriceItems, opt => opt.MapFrom(src => src.DS_OutcomeItems));

            CreateMap<DS_OutcomeItems, Entities.DS_IncomePriceItems>().
                ForMember(dest => dest.ProductUnitID, opt => opt.MapFrom(src => src.ProductUnitID)).
                ForMember(dest => dest.OperationalDay, opt => opt.MapFrom(src => src.OperationalDay)).
                ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber)).
                ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            //CreateMap<Models.DS_OutcomeItems, Entities.DS_IncomePriseSimpleItemItems>().
            //    ForMember(dest => dest.EnterDate, opt => opt.MapFrom(src => src.OperationalDay)).
            //    ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Quantity)).
            //    ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber));

            CreateMap<Entities.DS_IncomePriceItems, Entities.DS_IncomePriseSimpleItemItems>().
                ForMember(dest => dest.EnterDate, opt => opt.MapFrom(src => src.OperationalDay)).
                ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Quantity)).
                ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber));
        }
    }
}
