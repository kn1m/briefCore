namespace briefCore.Controllers.Controllers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class WishlistController : Controller
    {
        public WishlistController()
        {
            
        }

        public Task<HttpResponseMessage> AddEditionToWishList(Guid editionId)
        {
            return null;
        }
        
        public Task<HttpResponseMessage> RemoveEditionToWishList(Guid editionId)
        {
            return null;
        }
    }
}