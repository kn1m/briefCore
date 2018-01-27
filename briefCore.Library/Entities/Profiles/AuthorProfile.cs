﻿namespace briefCore.Library.Entities.Profiles
{
    using System;
    using AutoMapper;
    using brief.Controllers.Models;
    using brief.Library.Entities;

    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorModel>();

            CreateMap<AuthorModel, Author>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id ?? Guid.NewGuid()));
        }
    }
}