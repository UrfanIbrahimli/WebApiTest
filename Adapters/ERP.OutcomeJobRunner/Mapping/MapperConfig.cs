using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.OutcomeJobRunner
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;
            CreateMap<OutcomeService.DS_Outcome,OutcomeWebApi.Models.DS_Outcome>().ReverseMap();
            CreateMap<OutcomeService.DS_OutcomeItems,OutcomeWebApi.Models.DS_OutcomeItems>().ReverseMap();
        }
    }
}
