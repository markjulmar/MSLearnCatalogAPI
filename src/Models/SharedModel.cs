using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MSLearnCatalogAPI
{
    public abstract class SharedModel
    {
        public string Summary { get; set; }
        public List<string> Levels { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Products { get; set; }
        public string Uid { get; set; }
        public string Title { get; set; }
        [JsonProperty("duration_in_minutes")]
        public int Duration { get; set; }
        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }
        public string Locale { get; set; }
        [JsonProperty("last_modified")]
        public DateTime LastModified { get; set; }
        public string Url { get; set; }
    }
}
