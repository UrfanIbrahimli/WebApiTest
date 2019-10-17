using AutoMapper;
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
            CreateMap<ERP.StockService.DS_IncomePrice, ERP.JobRunner.Models.DS_IncomePrice>().ReverseMap();
            CreateMap<ERP.StockService.DS_Outcome, ERP.JobRunner.Models.DS_Outcome>().ReverseMap();
        }
    }
}
