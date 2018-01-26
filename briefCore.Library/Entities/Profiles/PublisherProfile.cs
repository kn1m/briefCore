﻿namespace briefCore.Library.Entities.Profiles
{
    using System;
    using AutoMapper;
    using brief.Controllers.Models;
    using brief.Library.Entities;

    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherModel>();

            CreateMap<PublisherModel, Publisher>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id ?? Guid.NewGuid()));
        }
    }
}
