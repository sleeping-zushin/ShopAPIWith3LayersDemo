using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapper
{
    public partial class MapperConfigs : Profile
    {
        partial void CreateProductMap()
        {
            CreateMap<ProductVM, Product>().ReverseMap();
            CreateMap<ProductAddVM, Product>().ReverseMap();
        }
    }
}
