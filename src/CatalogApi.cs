using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MSLearnCatalogAPI
{
    /// <summary>
    /// This library wraps the [MS Learn Catalog API](https://docs.microsoft.com/en-us/learn/support/catalog-api).
    /// It provides a simple .NET wrapper to retrieve the published modules, paths, products, levels, and roles from the live system.
    /// </summary>
    public static class CatalogApi
    {
        const string Url = "https://docs.microsoft.com/api/learn/catalog";
        const string Locale = "?locale={0}";

        public static Task<LearnCatalog> GetCatalog()
        {
            return GetCatalog(null);
        }

        public static async Task<LearnCatalog> GetCatalog(string locale)
        {
            string endpoint = Url;
            if (!string.IsNullOrWhiteSpace(locale))
                endpoint += string.Format(Locale, WebUtility.HtmlEncode(locale));

            using var client = new HttpClient();
            string results = await client.GetStringAsync(endpoint).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<LearnCatalog>(results,
                new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                });
        }
    }
}
