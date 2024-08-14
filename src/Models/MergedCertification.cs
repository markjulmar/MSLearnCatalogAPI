using Newtonsoft.Json;
using System.Diagnostics;

namespace MSLearnCatalogAPI;

/// <summary>
/// This represents a public certification record merged with an exam.
/// </summary>
[DebuggerDisplay("{Title} - [{Uid}]")]
public sealed class MergedCertification : BaseSharedModel
{
    /// <summary>
    /// A fully qualified URL to a 100x100 SVG image that represents
    /// the achievement image with a transparent background.
    /// </summary>
    [JsonProperty("icon_url")]
    public string IconUrl { get; set; } = string.Empty;

    /// <summary>
    /// The type of certification. 
    /// The possible values are 'fundamentals', 'mce', 'mcsa', 'mcsd', 'mcse', 
    /// 'mos', 'mta', 'role-based', 'specialty'.
    /// </summary>
    [JsonProperty("certification_type")]
    public string CertificationType {get;set;} = string.Empty;

    /// <summary>
    /// The number of days before this certification expires and needs to be renewed. 
    /// If the value is 0, the certification doesn't expire.
    /// </summary>
    [JsonProperty("renewal_frequency_in_days")]
    public int RenewalFrequencyInDays {get;set;}

    /// <summary>
    /// A list of the recommended pre-requisites to earn this certification. 
    /// Details about the certifications can be referenced in the certification records.
    /// </summary>
    public List<string> Prerequisites { get; set; } = new();

    /// <summary>
    /// A list of the skills measured on the exam required for this certification.
    /// </summary>
    public List<string> Skills {get;set; } = new();

    /// <summary>
    /// A list of the recommended resources related to this certification.
    /// </summary>
    [JsonProperty("recommendation_list")]
    public List<string> Recommendations { get; set; } = new();

    /// <summary>
    /// Study guide for this applied skill.
    /// </summary>
    [JsonProperty("study_guide")]
    public List<StudyGuide> StudyGuide { get; set; } = new();

    /// <summary>
    /// The number of minutes allotted to complete the exam.
    /// </summary>
    [JsonProperty("exam_duration_in_minutes")]
    public int ExamDurationInMinutes {get;set;}

    /// <summary>
    /// A list of the locales this certification is offered in.
    /// </summary>
    public List<string> Locales {get;set; } = new();

    /// <summary>
    /// A list of providers for this certification. 
    /// The type describes which provider and a fully qualified URL with a 
    /// link to schedule an exam with the provider.
    /// </summary>
    public List<ExamProvider> Providers {get;set; } = new();

    /*
    /// <summary>
    /// A list of career paths for this certification.
    /// </summary>
    [JsonProperty("career_paths")]
    public List<string> CareerPaths {get;set; } = new();
    */

    /// <summary>
    /// Returns a textual version of this object.
    /// </summary>
    /// <returns>String</returns>
    public override string ToString() => Title;
}