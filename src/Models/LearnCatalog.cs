namespace MSLearnCatalogAPI;

/// <summary>
/// This is the root object returned by the Catalog API
/// </summary>
public class LearnCatalog
{
    /// <summary>
    /// List of available modules.
    /// </summary>
    public List<Module> Modules { get; set; } = new();

    /// <summary>
    /// List of available Learning Paths
    /// </summary>
    public List<LearningPath> LearningPaths { get; set; } = new();

    /// <summary>
    /// Levels used in modules/paths.
    /// </summary>
    public List<Level> Levels { get; set; } = new();

    /// <summary>
    /// Roles used in modules/paths.
    /// </summary>
    public List<Role> Roles { get; set; } = new();

    /// <summary>
    /// Products used in modules/paths.
    /// </summary>
    public List<Product> Products { get; set; } = new();

    /// <summary>
    /// Returns the modules tied to a specific Learning path.
    /// </summary>
    /// <param name="path">Path to get modules for</param>
    /// <returns>Enumerable list of modules</returns>
    public IEnumerable<Module> ModulesForPath(LearningPath path)
    {
        if (path == null) throw new ArgumentNullException(nameof(path));
        foreach (var uid in path.Modules)
        {
            var module = Modules.SingleOrDefault(m2 => m2.Uid == uid);
            if (module != null) 
                yield return module;
        }
    }
}