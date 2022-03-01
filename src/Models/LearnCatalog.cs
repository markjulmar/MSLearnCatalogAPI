namespace MSLearnCatalogAPI;

/// <summary>
/// This is the root object returned by the Catalog API
/// </summary>
public class LearnCatalog
{
    /// <summary>
    /// List of available modules.
    /// </summary>
    public List<Module> Modules { get; set; }

    /// <summary>
    /// List of available Learning Paths
    /// </summary>
    public List<LearningPath> LearningPaths { get; set; }

    /// <summary>
    /// Levels used in modules/paths.
    /// </summary>
    public List<Level> Levels { get; set; }

    /// <summary>
    /// Roles used in modules/paths.
    /// </summary>
    public List<Role> Roles { get; set; }

    /// <summary>
    /// Products used in modules/paths.
    /// </summary>
    public List<Product> Products { get; set; }

    /// <summary>
    /// Returns the modules tied to a specific Learning path.
    /// </summary>
    /// <param name="path">Path to get modules for</param>
    /// <returns>Enumerable list of modules</returns>
    public IEnumerable<Module> ModulesForPath(LearningPath path) =>
        path.Modules.Select(m => Modules.SingleOrDefault(m2 => m2.Uid == m))
            .Where(m => m != null);

    /// <summary>
    /// Constructor
    /// </summary>
    internal LearnCatalog() { }
}