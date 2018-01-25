using System.Collections.Generic;
using briefCore.Controllers.Helpers.Base;

namespace brief.Controllers.Helpers
{
    public class HeaderSettings : IHeaderSettings
    {
        public Dictionary<string, string[]> AcceptableValuesForHeader { get; set; }
    }
}
