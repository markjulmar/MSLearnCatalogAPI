using System.Diagnostics;
using Newtonsoft.Json;

namespace MSLearnCatalogAPI;

/// <summary>
/// This represents a single Learning Path on Microsoft Learn
/// </summary>
[DebuggerDisplay("{Title} - [{Uid}]")]
public class LearningPath : SharedModel
{
    /// <summary>
    /// URL of the first module in this learning path.
    /// </summary>
    public string FirstModuleUrl { get; set; }

    /// <summary>
    /// List of module UIDs associated with this path.
    /// </summary>
    public List<string> Modules { get; set; }

    /// <summary>
    /// Number of modules in this learning path.
    /// </summary>
    [JsonProperty("number_of_children")]
    public int NumberOfModules { get; set; }
}