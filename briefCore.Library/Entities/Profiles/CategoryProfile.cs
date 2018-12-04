namespace briefCore.Library.Entities.Profiles
{
    using AutoMapper;
    using Controllers.Models;

    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();
        }
    }
}