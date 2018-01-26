namespace briefCore.Library.Entities.Profiles
{
    using System;
    using AutoMapper;
    using brief.Controllers.Models;
    using brief.Library.Entities;

    public class SeriesProfile : Profile
    {
        public SeriesProfile()
        {
            CreateMap<Series, SeriesModel>();

            CreateMap<SeriesModel, Series>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id ?? Guid.NewGuid()));
        }
    }
}
