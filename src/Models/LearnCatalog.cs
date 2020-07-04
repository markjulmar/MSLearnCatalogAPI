using System.Collections.Generic;

namespace MSLearnCatalogAPI
{
    public class LearnCatalog
    {
        public List<Module> Modules { get; set; }
        public List<LearningPath> LearningPaths { get; set; }
        public List<Level> Levels { get; set; }
        public List<Role> Roles { get; set; }
        public List<Product> Products { get; set; }
    }
}
