## MS Learn Catalog API

![Build and Publish MSLearn Catalog API library](https://github.com/markjulmar/MSLearnCatalogAPI/workflows/Build%20and%20Publish%20MSLearn%20Catalog%20API%20library/badge.svg)

This library wraps the [MS Learn Catalog API](https://learn.microsoft.com/en-us/training/support/catalog-api). It provides a simple .NET wrapper to retrieve the published modules, paths, products, levels, and roles from the live system.

> **Note**+: the API only returns public modules that the browse experience on Microsoft Learn shows.

### Usage

A single static method returns all five elements together:

```csharp
using MSLearnCatalogAPI;

LearnCatalog learnCatalog = await CatalogApi.GetCatalogAsync(null);

foreach (var module in learnCatalog.Modules.Where(m => m.Title.StartsWith("Intro"))
{
	Console.WriteLine($"{module.Uid} - {module.Title}")
}
```

Here's the `LearnCatalog` type:

```csharp
public class LearnCatalog
{
    public List<Module> Modules { get; set; }
    public List<LearningPath> LearningPaths { get; set; }
    public List<Level> Levels { get; set; }
    public List<Role> Roles { get; set; }
    public List<Product> Products { get; set; }
}
```

## Types

```csharp
public class Module
{
    public string Summary { get; set; }
    public List<string> Levels { get; set; }
    public List<string> Roles { get; set; }
    public List<string> Products { get; set; }
    public string Uid { get; set; }
    public string Title { get; set; }
    public int Duration { get; set; }
    public string IconUrl { get; set; }
    public string SocialImageUrl { get; set; }
    public string Locale { get; set; }
    public DateTime LastModified { get; set; }
    public string Url { get; set; }
    public int NumberOfUnits { get; set; }
    public List<string> Units { get; set; }
}

public class LearningPath : SharedModel
{
    public string Summary { get; set; }
    public List<string> Levels { get; set; }
    public List<string> Roles { get; set; }
    public List<string> Products { get; set; }
    public string Uid { get; set; }
    public string Title { get; set; }
    public int Duration { get; set; }
    public string IconUrl { get; set; }
    public string SocialImageUrl { get; set; }
    public string Locale { get; set; }
    public DateTime LastModified { get; set; }
    public string Url { get; set; }
    public List<string> Modules { get; set; }
    public int NumberOfModules { get; set; }
}

public class Level
{ 
    public string Id { get; set; }
    public string Name { get; set; }
}

public class Role
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public class TaxonomyIdName
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public class Product : TaxonomyIdName
{
    public List<TaxonomyIdName> Children { get; set; }
}
```
