using Newtonsoft.Json;
using System.Diagnostics;

namespace MSLearnCatalogAPI;

/// <summary>
/// This represents a single Learning Path on Microsoft Learn
/// </summary>
[DebuggerDisplay("{Title} - [{Uid}]")]
public sealed class AppliedSkill : BaseSharedModel
{
    /// <summary>
    /// Study guide for this applied skill.
    /// </summary>
    [JsonProperty("study_guide")]
    public List<StudyGuide> StudyGuides { get; set; } = new();

    /// <summary>
    /// Returns a textual version of this object.
    /// </summary>
    /// <returns>String</returns>
    public override string ToString() => Title;
}
