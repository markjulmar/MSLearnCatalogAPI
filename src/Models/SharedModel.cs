using Newtonsoft.Json;

namespace MSLearnCatalogAPI;

/// <summary>
/// Shared data between Learning Paths and Modules.
/// </summary>
public abstract class SharedModel
{
    /// <summary>
    /// Summary of the module or path.
    /// </summary>
    public string Summary { get; set; } = string.Empty;

    /// <summary>
    /// Levels this module or path are tied to.
    /// </summary>
    public List<string> Levels { get; set; } = new();

    /// <summary>
    /// Roles this module or path are relevant to.
    /// </summary>
    public List<string> Roles { get; set; } = new();

    /// <summary>
    /// Products this module or path are relevant to.
    /// </summary>
    public List<string> Products { get; set; } = new();

    /// <summary>
    /// Unique identifier for the module or path.
    /// </summary>
    public string Uid { get; set; } = string.Empty;

    /// <summary>
    /// Title of the module or path.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Expected duration in minutes of this module or path.
    /// </summary>
    [JsonProperty("duration_in_minutes")]
    public int Duration { get; set; }

    /// <summary>
    /// Star rating for this module or path.
    /// </summary>
    public Rating Rating { get; set; } = new();

    /// <summary>
    /// Popularity of this module or path.
    /// </summary>
    public double Popularity { get; set; }

    /// <summary>
    /// Icon URL for this module or path.
    /// </summary>
    [JsonProperty("icon_url")]
    public string IconUrl { get; set; } = string.Empty;

    /// <summary>
    /// Url for a social badge/image for this module or path.
    /// </summary>
    [JsonProperty("social_image_url")]
    public string SocialImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// Locale language for this module or path.
    /// </summary>
    public string Locale { get; set; } = string.Empty;

    /// <summary>
    /// Last modified date for this module or path.
    /// </summary>
    [JsonProperty("last_modified")]
    public DateTime LastModified { get; set; }

    /// <summary>
    /// URL for this module or path. This includes the
    /// locale and tracking query string information.
    /// </summary>
    [JsonProperty("url")]
    public string TrackedUrl { get; set; } = string.Empty;

    /// <summary>
    /// Returns the base URL for this module or path.
    /// This is the URL with no tracking data or locale.
    /// </summary>
    public string Url
    {
        get
        {
            var uri = new Uri(TrackedUrl);
            var parts = uri.GetLeftPart(UriPartial.Path).Split('/');
            return $"{uri.Scheme}://{uri.Host}/" + string.Join('/', parts.Skip(4));
        }
    }
}