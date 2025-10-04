using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapper
{
    public partial class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            // CreateMap<Source, Destination>();
            CreateProductMap();
            CreateUserMap();
        }

        partial void CreateProductMap();
        partial void CreateUserMap();
    }
}
