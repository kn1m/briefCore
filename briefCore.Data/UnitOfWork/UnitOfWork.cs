﻿namespace briefCore.Data.UnitOfWork
{
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
        private readonly ITranslatorRepository _translatorRepository;
        private readonly ICategoryRepository _categoryRepository;
        
        public UnitOfWork([NotNull]IBookRepository bookRepository,
                          [NotNull]ISeriesRepository seriesRepository,
                          [NotNull]IAuthorRepository authorRepository,
                          [NotNull]ICoverRepository coverRepository,
                          [NotNull]IEditionFileRepository editionFileRepository,
                          [NotNull]IEditionRepository editionRepository,
                          [NotNull]IPublisherRepository publisherRepository,
                          [NotNull]IDeviceRepository deviceRepository,
                          [NotNull]IUserDeviceRepository userDeviceRepository)
        {
            Guard.AssertNotNull(bookRepository, nameof(bookRepository));
            Guard.AssertNotNull(seriesRepository, nameof(seriesRepository));
            Guard.AssertNotNull(authorRepository, nameof(authorRepository));
            Guard.AssertNotNull(coverRepository, nameof(coverRepository));
            Guard.AssertNotNull(editionFileRepository, nameof(editionFileRepository));
            Guard.AssertNotNull(editionRepository, nameof(editionRepository));
            Guard.AssertNotNull(publisherRepository, nameof(publisherRepository));
            Guard.AssertNotNull(deviceRepository, nameof(deviceRepository));
            Guard.AssertNotNull(userDeviceRepository, nameof(userDeviceRepository));
            
            _bookRepository = bookRepository;
            _seriesRepository = seriesRepository;
            _authorRepository = authorRepository;
            _coverRepository = coverRepository;
            _editionFileRepository = editionFileRepository;
            _editionRepository = editionRepository;
            _publisherRepository = publisherRepository;
            _deviceRepository = deviceRepository;
            _userDeviceRepository = userDeviceRepository;
        }

        public IBookRepository GetBookRepository()
            => _bookRepository;

        public IAuthorRepository GetAuthorRepository()
            => _authorRepository;

        public ICoverRepository GetCoverRepository()
            => _coverRepository;

        public IDeviceRepository GetDeviceRepository()
            => _deviceRepository;

        public IUserDeviceRepository GetUserDeviceRepository()
            => _userDeviceRepository;

        public ISeriesRepository GetSeriesRepository()
            => _seriesRepository;

        public IEditionFileRepository GetEditionFileRepository()
            => _editionFileRepository;

        public IEditionRepository GetEditionRepository()
            => _editionRepository;

        public IPublisherRepository GetPublisherRepository()
            => _publisherRepository;

        public INoteRepository GetNoteRepository()
        {
            throw new System.NotImplementedException();
        }

        public ITranslatorRepository GetTranslatorRepository()
            => _translatorRepository;

        public ICategoryRepository GetCategoryRepository()
            => _categoryRepository;
    }
}