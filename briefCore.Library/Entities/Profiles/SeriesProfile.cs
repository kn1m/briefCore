namespace briefCore.Library.Entities.Profiles
{
    using System;
    using AutoMapper;
    using brief.Library.Entities;
    using Controllers.Models;

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
