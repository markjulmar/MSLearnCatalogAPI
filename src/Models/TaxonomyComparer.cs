using System.Collections.Generic;

namespace MSLearnCatalogAPI
{
    public class TaxonomyComparer : IEqualityComparer<TaxonomyIdName>
    {
        public bool Equals(TaxonomyIdName x, TaxonomyIdName y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            return x.Id.Equals(y.Id) && x.Name.Equals(y.Name);
        }

        public int GetHashCode(TaxonomyIdName obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
