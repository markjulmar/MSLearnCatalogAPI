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
        const string Url = "https://docs.microsoft.com/api/learn/catalog/?locale={0}";

        public static async Task<LearnCatalog> GetCatalog(string locale = "en-us")
        {
            using var client = new HttpClient();
            string results = await client.GetStringAsync(string.Format(Url, WebUtility.HtmlEncode(locale)))
                                         .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<LearnCatalog>(results,
                new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                });
        }
    }
}
