namespace MSLearnCatalogAPI;

/// <summary>
/// Tree of products available in Microsoft Learn
/// </summary>
public class Product : TaxonomyIdName
{
    /// <summary>
    /// Child products related to this product.
    /// </summary>
    public List<TaxonomyIdName> Children { get; set; }
}