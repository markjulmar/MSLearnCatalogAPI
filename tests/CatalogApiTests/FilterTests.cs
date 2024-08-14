using MSLearnCatalogAPI;

namespace CatalogApiTests;

public class FilterTests
{
    [Fact]
    public async Task OnlyModulesFetched()
    {
        var catalog = await CatalogApi.GetCatalogAsync(
            filters: new()
            {
                Types = CatalogTypes.Modules
            });

        Assert.Empty(catalog.LearningPaths);
        Assert.Empty(catalog.Roles);
        Assert.Empty(catalog.Exams);
        Assert.Empty(catalog.Courses);
        Assert.Empty(catalog.Certifications);
        Assert.Empty(catalog.Units);
        Assert.Empty(catalog.Products);
        Assert.Empty(catalog.Subjects);
    }

    [Fact]
    public async Task SingleModuleFetched()
    {
        const string uid = "learn-dynamics.get-started-financial-management-in-dynamics-365-finance-ops";

        var catalog = await CatalogApi.GetCatalogAsync(
            filters: new()
            {
                Uids = new() { uid }
            });

        Assert.Single(catalog.Modules);

        var module = catalog.Modules[0];
        Assert.Equal(uid, module.Uid);
        Assert.Equal("Get started with Dynamics 365 Finance", module.ToString());

        Assert.Empty(catalog.LearningPaths);
        Assert.Empty(catalog.Roles);
        Assert.Empty(catalog.Exams);
        Assert.Empty(catalog.Courses);
        Assert.Empty(catalog.Certifications);
        Assert.Empty(catalog.Units);
        Assert.Empty(catalog.Products);
        Assert.Empty(catalog.Subjects);
    }

    [Fact]
    public async Task CanFetchNonUsLocale()
    {
        const string uid = "learn.wwl.implement-manage-networking-for-azure-virtual-desktop";

        var catalog = await CatalogApi.GetCatalogAsync("es-ES",
            filters: new()
            {
                Uids = new() { uid }
            });

        var module = catalog.Modules[0];
        Assert.Equal(uid, module.Uid);
        Assert.Equal("es-es", module.Locale);
        Assert.Equal("Implementación y administración de redes de Azure Virtual Desktop", module.Title);
        
        Assert.Single(catalog.Modules);

        Assert.Empty(catalog.LearningPaths);
        Assert.Empty(catalog.Roles);
        Assert.Empty(catalog.Exams);
        Assert.Empty(catalog.Courses);
        Assert.Empty(catalog.Certifications);
        Assert.Empty(catalog.Units);
        Assert.Empty(catalog.Products);
        Assert.Empty(catalog.Subjects);
    }

    [Fact]
    public async Task CheckCertificationFilters()
    {
        var catalog = await CatalogApi.GetCatalogAsync(
            filters: new CatalogFilter
            {
                Types = CatalogTypes.Certifications | CatalogTypes.Courses | CatalogTypes.Exams,
                LastModifiedExpression = ">= 2022-12-01",
                Levels = new() { "advanced" },
                Roles = new() { "administrator " },
            });

        Assert.Empty(catalog.Modules);
        Assert.Empty(catalog.LearningPaths);
        Assert.Empty(catalog.Units);

        Assert.NotEmpty(catalog.Certifications);
        Assert.NotEmpty(catalog.Courses);
        Assert.NotEmpty(catalog.Exams);

        /*
        var expectedExams = catalog.Certifications.SelectMany(c => c.Exams);
        Assert.All(expectedExams, l => 
            Assert.Contains(l, catalog.Exams.Select(exam => exam.Uid)));

        expectedExams = catalog.Courses.Select(c => c.Exam);
        Assert.All(expectedExams, l =>
            Assert.Contains(l, catalog.Exams.Select(exam => exam.Uid)));
        */
    }
}