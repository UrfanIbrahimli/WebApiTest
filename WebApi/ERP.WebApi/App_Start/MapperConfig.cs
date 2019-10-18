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
            CreateMap<ERP.JobRunner.Models.DS_IncomePrice, ERP.WebApi.Entity.DS_IncomePrice>().ReverseMap();
            CreateMap<ERP.JobRunner.Models.DS_Outcome, ERP.WebApi.Entity.DS_Outcome>().ReverseMap();
        }
    }
}
