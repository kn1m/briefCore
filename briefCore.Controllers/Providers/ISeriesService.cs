namespace briefCore.Controllers.Providers
{
    using System;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Models;
    using Models.BaseEntities;

    public interface ISeriesService
    {
        Task<ResponseMessage<(Guid bookId, Guid seriesId)>> AddBookToSeries(Guid bookId, Guid seriesId);
        Task<ResponseMessage<(Guid bookId, Guid seriesId)>> RemoveBookFromSeries(Guid bookId, Guid seriesId);
        Task<BaseResponseMessage> CreateSeries([NotNull]SeriesModel series);
        Task<BaseResponseMessage> UpdateSeries([NotNull]SeriesModel series);
        Task<BaseResponseMessage> RemoveSeries(Guid id, bool removeBooks);
    }
}
