namespace MSLearnCatalogAPI;

/// <summary>
/// Simple comparer for the Taxonomy id/name pairs.
/// </summary>
public sealed class TaxonomyComparer : IEqualityComparer<TaxonomyIdName>
{
    /// <summary>
    /// Determines whether the specified objects are equal.
    /// </summary>
    /// <param name="x">The first TaxonomyIdName to compare.</param>
    /// <param name="y">The second TaxonomyIdName to compare.</param>
    /// <returns>True if the specified objects are equal; otherwise, False.</returns>
    public bool Equals(TaxonomyIdName? x, TaxonomyIdName? y) 
        => x == null && y == null || x != null && y != null && x.Id.Equals(y.Id) && x.Name.Equals(y.Name);

    /// <summary>
    /// Returns a hash code for the specified object.
    /// </summary>
    /// <param name="obj">The TaxonomyIdName for which a hash code is to be returned.</param>
    /// <returns>A hash code for the specified object.</returns>
    public int GetHashCode(TaxonomyIdName obj) 
        => obj.Id.GetHashCode();
}