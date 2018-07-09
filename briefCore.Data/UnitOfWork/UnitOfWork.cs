namespace briefCore.Data.UnitOfWork
{
    using brief.Library.Repositories;
    using JetBrains.Annotations;
    using Library.Helpers;
    using Library.Repositories;
    using Library.UnitOfWork;
    
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IBookRepository _bookRepository;
        private readonly ISeriesRepository _seriesRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICoverRepository _coverRepository;
        private readonly IEditionFileRepository _editionFileRepository;
        private readonly IEditionRepository _editionRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IUserDeviceRepository _userDeviceRepository;
        
        public UnitOfWork([NotNull]IBookRepository bookRepository)
        {
            Guard.AssertNotNull(bookRepository, nameof(bookRepository));

            _bookRepository = bookRepository;
        }

        public IBookRepository GetBookRepository()
        {
            throw new System.NotImplementedException();
        }

        public IAuthorRepository GetAuthorRepository()
        {
            throw new System.NotImplementedException();
        }

        public ICoverRepository GetCoverRepository()
        {
            throw new System.NotImplementedException();
        }

        public IDeviceRepository GetDeviceRepository()
        {
            throw new System.NotImplementedException();
        }

        public IUserDeviceRepository GetIUserDeviceRepository()
        {
            throw new System.NotImplementedException();
        }

        public ISeriesRepository GetSeriesRepository()
        {
            throw new System.NotImplementedException();
        }

        public IEditionFileRepository GetEditionFileRepository()
        {
            throw new System.NotImplementedException();
        }

        public IEditionRepository GetEditionRepository()
        {
            throw new System.NotImplementedException();
        }

        public IPublisherRepository GetPublisherRepository()
        {
            throw new System.NotImplementedException();
        }

        public INoteRepository GetNoteRepository()
        {
            throw new System.NotImplementedException();
        }
    }
}