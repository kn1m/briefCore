namespace briefCore.Controllers.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.BaseEntities;
    using Providers;

    [Authorize]
    [Route("api/[controller]/[action]")]
    public class DeviceController : Controller
    {
        private readonly IDeviceService _deviceService;
        
        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService ?? throw new ArgumentNullException(nameof(deviceService));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public Task<BaseResponseMessage> CreateDevice(DeviceModel deviceModel)
        {
            return null;
        }
        
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public Task<BaseResponseMessage> UpdateDevice(DeviceModel deviceModel)
        {
            return null;
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public Task<BaseResponseMessage> RemoveDevice(Guid id)
        {
            return null;
        }
    }
}