namespace briefCore.Controllers.Controllers.BaseControllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    [Authorize]
    public class BaseAuthorizeController : Controller
    {
        
    }
}