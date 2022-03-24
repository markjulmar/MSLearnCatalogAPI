using System.Net;
using Newtonsoft.Json;

namespace MSLearnCatalogAPI;

/// <summary>
/// This library wraps the [MS Learn Catalog API](https://docs.microsoft.com/en-us/learn/support/catalog-api).
/// It provides a simple .NET wrapper to retrieve the published modules, paths, products, levels, and roles from the live system.
/// </summary>
public static class CatalogApi
{
    const string Url = "https://docs.microsoft.com/api/learn/catalog";
    const string Locale = "?locale={0}";

    /// <summary>
    /// Returns the Learn catalog using the locale of the HTTP request.
    /// </summary>
    /// <returns>Learn Catalog of modules, paths, and relationships</returns>
    public static Task<LearnCatalog> GetCatalogAsync() => GetCatalogAsync(string.Empty);

    /// <summary>
    /// Returns the Learn catalog for the specified locale.
    /// </summary>
    /// <param name="locale">Language locale (en-us)</param>
    /// <returns>Learn Catalog of modules, paths, and relationships</returns>
    public static async Task<LearnCatalog> GetCatalogAsync(string locale)
    {
        string endpoint = Url;
        if (!string.IsNullOrWhiteSpace(locale))
            endpoint += string.Format(Locale, WebUtility.HtmlEncode(locale));

        using var client = new HttpClient();
        string results = await client.GetStringAsync(endpoint).ConfigureAwait(false);

        var catalog = JsonConvert.DeserializeObject<LearnCatalog>(results,
            new JsonSerializerSettings {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            });

        if (catalog == null)
            throw new InvalidOperationException(
                "Unable to parse results from Learn Catalog - possibly outdated schema?");
        
        // Fill in path ratings
        foreach (var path in catalog.LearningPaths.Where(p => p.Rating?.Count == 0))
        {
            var modules = catalog.ModulesForPath(path).ToList();
            if (modules.Any(m => m.Rating.Count > 0))
            {
                path.Rating.Count = modules.Sum(m => m.Rating.Count);
                path.Rating.Average = modules.Average(m => m.Rating.Average);
            }
        }

        return catalog;
    }
}