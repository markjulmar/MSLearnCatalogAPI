using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace MSLearnCatalogAPI
{
    [DebuggerDisplay("{Title} - [{Uid}]")]
    public class Module : SharedModel
    {
        public string FirstUnitUrl { get; set; }

        [JsonProperty("number_of_children")]
        public int NumberOfUnits { get; set; }

        public string BaseUrl()
        {
            var uri = new Uri(Url);
            var rs = uri.Scheme + "://" + uri.Authority + "/";
            for (int i = 2; i < uri.Segments.Length; i++)
                rs += uri.Segments[i];
            return rs;
        }
    }
}
