namespace briefCore.Controllers.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        public CategoryController()
        {
            
        }
    }
}