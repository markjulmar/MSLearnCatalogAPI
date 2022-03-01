namespace MSLearnCatalogAPI;

/// <summary>
/// Identifier + Name pair used for levels, roles, and products.
/// </summary>
public class TaxonomyIdName
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Readable name.
    /// </summary>
    public string Name { get; set; }
}