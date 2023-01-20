﻿namespace MSLearnCatalogAPI;

/// <summary>
/// Subjects available in Microsoft Learn
/// </summary>
public sealed class Subject : TaxonomyIdName
{
    /// <summary>
    /// Child subjects related to this parent.
    /// </summary>
    public List<TaxonomyIdName> Children { get; set; } = new();
}