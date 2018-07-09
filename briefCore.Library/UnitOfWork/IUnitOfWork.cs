namespace briefCore.Library.UnitOfWork
{
    using Repositories;

    public interface IUnitOfWork
    {
        IBookRepository GetBookRepository();
        IAuthorRepository GetAuthorRepository();
        ICoverRepository GetCoverRepository();
        IDeviceRepository GetDeviceRepository();
        IUserDeviceRepository GetIUserDeviceRepository();
        ISeriesRepository GetSeriesRepository();
        IEditionFileRepository GetEditionFileRepository();
        IEditionRepository GetEditionRepository();
        IPublisherRepository GetPublisherRepository();
        INoteRepository GetNoteRepository();
    }
}