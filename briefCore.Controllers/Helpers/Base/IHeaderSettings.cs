namespace briefCore.Controllers.Helpers.Base
{
    using System.Collections.Generic;

    public interface IHeaderSettings
    {
        Dictionary<string, string[]> AcceptableValuesForHeader { get; set; }
    }
}