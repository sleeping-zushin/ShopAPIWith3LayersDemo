using DataAccessLayer.Models;
using DataAccessLayer.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapper
{
    public partial class MapperConfigs
    {
        partial void CreateUserMap()
        {
            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<User, UserAddVM>().ReverseMap();
        }
    }
}
