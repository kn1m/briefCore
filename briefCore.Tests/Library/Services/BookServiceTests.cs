namespace briefCore.Tests.Library.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using briefCore.Library.UnitOfWork;
    using NUnit.Framework;

    [TestFixture]
    public class BookServiceTests
    {
        private IUnitOfWork _unitOfWork;

        [SetUp]
        public void SetUp()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            _unitOfWork = null;
        }
        
        [TestCaseSource(nameof(GetDataForCreateBook))]
        public async Task CreateBook()
        {
            
        }

        private static IEnumerable<TestCaseData> GetDataForCreateBook
        {
            get
            {
                yield return  new TestCaseData();
            }
        }
    }
}