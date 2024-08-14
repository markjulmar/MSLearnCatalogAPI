using MSLearnCatalogAPI;

var catalog = await CatalogApi.GetCatalogAsync();
Console.WriteLine($"Loaded {catalog.Modules.Count} Modules, {catalog.LearningPaths.Count} Learning Paths.");

Console.WriteLine("Average module rating: " +
    Math.Round(catalog.Modules.Where(m => m.Rating?.Count > 10)
                    .Average(m => m.Rating!.Average), 2));

Console.WriteLine();
Console.WriteLine("Latest published modules:");
foreach (var module in catalog.Modules.OrderByDescending(m => m.LastModified).Take(10))
    Console.WriteLine($"{module.Title} - {module.LastModified}");

Console.WriteLine();
Console.WriteLine("Most popular modules:");
foreach (var module in catalog.Modules.OrderByDescending(m => m.Popularity).Take(10))
    Console.WriteLine($"{module.Title} - {module.Popularity}");

Console.WriteLine();
Console.WriteLine("Top rated modules");
foreach (var module in catalog.Modules.Where(m => m.Rating?.Count > 0).OrderByDescending(m => m.Rating!.Average).Take(10))
    Console.WriteLine($"{module.Title} - {module.Rating?.Average}");

Console.WriteLine();
Console.WriteLine("Latest published paths:");
foreach (var path in catalog.LearningPaths.OrderByDescending(m => m.LastModified).Take(10))
    Console.WriteLine($"{path.Title} - {path.LastModified}");

Console.WriteLine();
Console.WriteLine("Most popular paths:");
foreach (var path in catalog.LearningPaths.OrderByDescending(m => m.Popularity).Take(10))
    Console.WriteLine($"{path.Title} - {path.Popularity}");

Console.WriteLine();
Console.WriteLine("Top rated paths");
foreach (var path in catalog.LearningPaths.Where(m => m.Rating?.Count > 0)
                            .OrderByDescending(m => m.Rating!.Average).Take(10))
    Console.WriteLine($"{path.Title} - {path.Rating?.Average}");

Console.WriteLine();
Console.WriteLine("Latest certifications");
foreach (var cert in catalog.Certifications.OrderByDescending(m => m.LastModified).Take(10))
    Console.WriteLine($"{cert.Title} - {cert.LastModified}");

Console.WriteLine();
Console.WriteLine("Latest applied skills");
foreach (var skill in catalog.AppliedSkills.OrderByDescending(m => m.LastModified).Take(10))
    Console.WriteLine($"{skill.Title} - {skill.LastModified}");