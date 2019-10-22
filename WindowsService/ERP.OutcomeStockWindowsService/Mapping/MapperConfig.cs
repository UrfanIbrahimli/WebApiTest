using AutoMapper;
using ERP.OutcomeStockWindowsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.OutcomeStockWindowsService.Mapping
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;
            CreateMap<DS_Outcome, OutcomeWebApi.Models.DS_Outcome>().ReverseMap();
            CreateMap<DS_OutcomeItems, OutcomeWebApi.Models.DS_OutcomeItems>().ReverseMap();
        }
    }
}
