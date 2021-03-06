﻿namespace briefCore.Controllers.Providers.ServiceProviders
{
    using System;
    using System.Linq;
    using Models;
    using Models.RetrieveModels;

    public interface IFilterService
    {
        IQueryable<BookRetrieveModel> GetBooks();
        IQueryable<BookRetrieveModel> GetBookById(Guid id);
        CoverModel GetCoverById(Guid id);
    }
}
