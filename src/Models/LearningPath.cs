using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace MSLearnCatalogAPI
{
    [DebuggerDisplay("{Title} - [{Uid}]")]
    public class LearningPath : SharedModel
    {
        public string FirstModuleUrl { get; set; }
        public List<string> Modules { get; set; }
        [JsonProperty("number_of_children")]
        public int NumberOfModules { get; set; }
    }
}
