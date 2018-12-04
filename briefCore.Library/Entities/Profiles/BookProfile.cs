namespace briefCore.Library.Entities.Profiles
{
    using AutoMapper;
    using Controllers.Models;
    using Controllers.Models.RetrieveModels;

    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookModel, Book>();

            CreateMap<Book, BookModel>();
            CreateMap<Book, BookRetrieveModel>();
        }
    }
}
