using AutoMapper;
using ERP.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.StockWindowsService.Mapping
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;
            CreateMap<Models.DS_IncomePrice, DS_IncomePrice>().ReverseMap();
            CreateMap<Models.DS_Outcome, DS_Outcome>().ReverseMap();
        }
    }
}
