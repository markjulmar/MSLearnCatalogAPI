using Microsoft.VisualBasic;
using MSLearnCatalogAPI;

namespace CatalogApiTests;

public class CatalogTests : IClassFixture<CatalogFixture>
{
    private readonly CatalogFixture fixture;

    public CatalogTests(CatalogFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public void AllModulePropertiesArePopulated()
    {
        string uid = "learn.azure.design-secure-environment-government";

        var module = fixture.Catalog.Modules.Single(m => m.Uid == uid);

        Assert.Equal(uid, module.Uid);
        Assert.NotEmpty(module.Summary);
            
        Assert.NotEmpty(module.Levels);
        Assert.NotEmpty(module.Roles);
        Assert.NotEmpty(module.Products);
        Assert.NotEmpty(module.Subjects);
            
        Assert.NotNull(module.Rating);
        Assert.True(module.Rating!.Count > 0);
        Assert.True(module.Popularity > 0);
        Assert.True(module.Duration > 0);

        Assert.NotEmpty(module.Url);
        Assert.NotEmpty(module.Locale);
        Assert.True(module.LastModified > new DateTime(2018,7,1));

        Assert.NotEmpty(module.IconUrl);
        Assert.NotEmpty(module.SocialImageUrl);
        Assert.NotEmpty(module.FirstUnitUrl);
        Assert.True(module.NumberOfUnits > 0);
        Assert.Equal(module.NumberOfUnits, module.Units.Count);
    }

    [Fact]
    public void AllLearningPathPropertiesArePopulated()
    {
        string uid = "learn.secure-application-delivery";

        var path = fixture.Catalog.LearningPaths.Single(lp => lp.Uid == uid);

        Assert.Equal(uid, path.Uid);
        Assert.NotEmpty(path.Summary);

        Assert.NotEmpty(path.Levels);
        Assert.NotEmpty(path.Roles);
        Assert.NotEmpty(path.Products);
        Assert.NotEmpty(path.Subjects);

        Assert.NotNull(path.Rating);
        Assert.True(path.Rating!.Count > 0);
        Assert.True(path.Popularity > 0);
        Assert.True(path.Duration > 0);

        Assert.NotEmpty(path.Url);
        //Assert.NotEmpty(path.Locale);
        Assert.True(path.LastModified > new DateTime(2018, 7, 1));

        Assert.NotEmpty(path.IconUrl);
        Assert.NotEmpty(path.SocialImageUrl);
        Assert.NotEmpty(path.FirstModuleUrl);
        Assert.True(path.NumberOfModules > 0);
        Assert.Equal(path.NumberOfModules, path.Modules.Count);
    }

    [Fact]
    public void AllUnitPropertiesArePopulated()
    {
        string uid = "learn.wwl.design-implement-private-access-to-azure-services.integrate-your-app-service-azure-virtual-networks";

        var unit = fixture.Catalog.Units.Single(unit => unit.Uid == uid);

        Assert.Equal(uid, unit.Uid);
        Assert.NotEmpty(unit.Title);
        Assert.True(unit.Duration > 0);

        Assert.NotEmpty(unit.Locale);
        Assert.True(unit.LastModified > new DateTime(2018, 7, 1));
    }

    [Fact]
    public void AllCertificationPropertiesArePopulated()
    {
        string uid = "certification.m365-security-administrator";

        var cert = fixture.Catalog.Certifications.Single(cert => cert.Uid == uid);

        Assert.Equal(uid, cert.Uid);
        Assert.NotEmpty(cert.Title);
        Assert.NotEmpty(cert.Subtitle);
        Assert.NotEmpty(cert.Url);
        Assert.NotEmpty(cert.IconUrl);
        
        Assert.NotEmpty(cert.CertificationType);
        Assert.True(cert.LastModified > new DateTime(2018, 7, 1));

        Assert.NotEmpty(cert.Exams);
        Assert.NotEmpty(cert.Levels);
        Assert.NotEmpty(cert.Roles);
        //Assert.NotEmpty(cert.Products);
        Assert.NotEmpty(cert.StudyGuide);
    }

    [Fact]
    public void AllExamPropertiesArePopulated()
    {
        string uid = "exam.az-800";

        var exam = fixture.Catalog.Exams.Single(exam => exam.Uid == uid);

        Assert.Equal(uid, exam.Uid);
        Assert.NotEmpty(exam.Title);
        Assert.NotEmpty(exam.Subtitle);
        Assert.NotEmpty(exam.DisplayName);
        Assert.NotEmpty(exam.Url);
        Assert.NotEmpty(exam.IconUrl);

        //Assert.NotEmpty(exam.Locales);
        //Assert.NotEmpty(exam.PdfUrl);
        //Assert.NotEmpty(exam.PracticeTestUrl);

        Assert.True(exam.LastModified > new DateTime(2018, 7, 1));

        Assert.NotEmpty(exam.Courses);
        Assert.NotEmpty(exam.Levels);
        Assert.NotEmpty(exam.Roles);
        Assert.NotEmpty(exam.Products);
        Assert.NotEmpty(exam.StudyGuide);
        Assert.NotEmpty(exam.Providers);
    }

    [Fact]
    public void AllCoursePropertiesArePopulated()
    {
        string uid = "course.mb-310t00";

        var course = fixture.Catalog.Courses.Single(course => course.Uid == uid);

        Assert.Equal(uid, course.Uid);
        Assert.NotEmpty(course.Title);
        Assert.NotEmpty(course.CourseNumber);
        Assert.NotEmpty(course.Summary);
        Assert.NotEmpty(course.Url);
        Assert.NotEmpty(course.IconUrl);
        Assert.True(course.Duration > 0);

        Assert.NotEmpty(course.Locales);
        Assert.NotEmpty(course.Certification);

        Assert.True(course.LastModified > new DateTime(2018, 7, 1));

        Assert.NotEmpty(course.Exam);
        Assert.NotEmpty(course.Levels);
        Assert.NotEmpty(course.Roles);
        Assert.NotEmpty(course.Products);
        Assert.NotEmpty(course.StudyGuide);
    }

    [Fact]
    public void ResponseHasLevels()
    {
        var levels = fixture.Catalog.Levels;
        Assert.NotEmpty(levels);

        var levelKeys = fixture.Catalog
            .Modules.SelectMany(m => m.Levels).Union(
                fixture.Catalog.LearningPaths.SelectMany(lp => lp.Levels))
            .Distinct().ToList();

        Assert.All(levelKeys, l => 
            Assert.Contains(l, levels.Select(l => l.Id)));
    }

    [Fact]
    public void ResponseHasRoles()
    {
        var roles = fixture.Catalog.Roles;
        Assert.NotEmpty(roles);

        var roleKeys = fixture.Catalog
            .Modules.SelectMany(m => m.Roles).Union(
                fixture.Catalog.LearningPaths.SelectMany(lp => lp.Roles))
            .Distinct().ToList();

        Assert.All(roleKeys, l =>
            Assert.Contains(l, roles.Select(l => l.Id)));
    }

    [Fact]
    public void ResponseHasSubjects()
    {
        var subjects = fixture.Catalog.Subjects;
        Assert.NotEmpty(subjects);

        var subjectKeys = fixture.Catalog
            .Modules.SelectMany(m => m.Subjects).Union(
                fixture.Catalog.LearningPaths.SelectMany(lp => lp.Subjects))
            .Distinct().ToList();

        var unrolled = subjects.Union(subjects.SelectMany(p => p.Children));
        Assert.All(subjectKeys, l => Assert.Contains(l, unrolled.Select(p => p.Id)));
    }

    [Fact]
    public void ResponseHasProducts()
    {
        var products = fixture.Catalog.Products;
        Assert.NotEmpty(products);

        var productKeys = fixture.Catalog
            .Modules.SelectMany(m => m.Products).Union(
                fixture.Catalog.LearningPaths.SelectMany(lp => lp.Products))
            .Distinct().ToList();

        var unrolled = products.Union(products.SelectMany(p => p.Children));
        Assert.All(productKeys, l => Assert.Contains(l, unrolled.Select(p => p.Id)));
    }

}

public class CatalogFixture : IAsyncLifetime
{
    public LearnCatalog Catalog { get; set; } = null!;

    public async Task InitializeAsync()
    {
        Catalog = await CatalogApi.GetCatalogAsync();
    }

    public async Task DisposeAsync()
    {
        // Nothing
    }
}

