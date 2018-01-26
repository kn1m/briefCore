namespace briefCore.Library.Entities.Profiles
{
    using System;
    using AutoMapper;
    using brief.Controllers.Models;
    using brief.Controllers.Models.RetrieveModels;
    using brief.Library.Entities;

    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookModel, Book>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id ?? Guid.NewGuid()));

            CreateMap<Book, BookModel>();
            CreateMap<Book, BookRetrieveModel>();
        }
    }
}
