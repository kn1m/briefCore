namespace briefCore.Controllers.Controllers
{
    using System;
    using Microsoft.AspNetCore.Authorization;
    using Providers;

    [Authorize]
    public class DeviceController
    {
        private readonly IDeviceService _deviceService;
        
        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService ?? throw new ArgumentNullException(nameof(deviceService));
        }
    }
}