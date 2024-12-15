namespace Catalog.API.Common.Helpers
{
    public static class Helper
    {
        public static bool HaveUniqueValues(List<long> categoryIds)
        {
            if (categoryIds == null) return true; // Handle null case gracefully
            return categoryIds.Distinct().Count() == categoryIds.Count();
        }
    }
}
