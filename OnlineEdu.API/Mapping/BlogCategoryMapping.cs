using AutoMapper;
using OnlineEdu.DTO.DTOs.BlogCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class BlockCategoryMapping:Profile
    {
        public BlockCategoryMapping()
        {
            CreateMap<ResultBlogCategoryDto,BlogCategory>().ReverseMap();
            CreateMap<CreateBlogCategoryDto,BlogCategory>().ReverseMap();
            CreateMap<UpdateBlogCategoryDto,BlogCategory>().ReverseMap();
        }
    }
}
