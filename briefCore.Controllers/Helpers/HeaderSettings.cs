namespace briefCore.Controllers.Helpers
{
    using System.Collections.Generic;
    using Base;

    public class HeaderSettings : IHeaderSettings
    {
        public Dictionary<string, string[]> AcceptableValuesForHeader { get; set; }
    }
}
