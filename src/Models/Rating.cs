namespace MSLearnCatalogAPI
{
    /// <summary>
    /// Star ratings
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Number of ratings recorded
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Average of recorded ratings (0-5)
        /// </summary>
        public double Average { get; set; }
    }
}