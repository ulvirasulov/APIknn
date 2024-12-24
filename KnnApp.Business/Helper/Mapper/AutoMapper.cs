using AutoMapper;
using KnnApp.Core.DTOs.Category;
using KnnApp.Core.DTOs.Product;
using KnnApp.Core.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnApp.Business.Helper.Mapper;
public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<CreateCategoryDTO, Category>().ReverseMap();
        CreateMap<UpdateCategoryDTO, Category>().ReverseMap();

        CreateMap<CreateProductDTO, Product>().ReverseMap();
        CreateMap<UpdateProductDTO, Product>().ReverseMap();
    }

}
