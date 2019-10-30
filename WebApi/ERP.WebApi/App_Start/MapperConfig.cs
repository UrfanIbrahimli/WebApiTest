using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.WebApi
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;
            CreateMap<Models.DS_IncomePrice, Entity.DS_IncomePrice>().ReverseMap();
            CreateMap<Models.DS_Outcome, Entity.DS_Outcome>().ReverseMap();
            CreateMap<Models.DS_OutcomeItems, Entity.DS_OutcomeItems>().ReverseMap();
        }
    }
}
