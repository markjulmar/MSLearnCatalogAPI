using System.Collections.Generic;

namespace MSLearnCatalogAPI
{
    public class Product : TaxonomyIdName
    {
        public List<TaxonomyIdName> Children { get; set; }
    }
}
