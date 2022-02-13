using AutoMapper;
using CityBL.Dto;
using CityDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBL.Mapper
{
    public class DomainProfiller:Profile
    {
        public DomainProfiller()
        {
            CreateMap<City,CityDto>();
            CreateMap<CityDto, City>().ForMember(src=>src.Logo,op=>op.Ignore());

        }
    }
}
