using AutoMapper;
using ERP.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.JobRunner.Mapping
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;
            CreateMap<ERP.StockService.DS_IncomePrice, DS_IncomePrice>().ReverseMap();
            CreateMap<ERP.StockService.DS_Outcome, DS_Outcome>().ReverseMap();
        }
    }
}
