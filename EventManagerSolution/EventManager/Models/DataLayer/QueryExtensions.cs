namespace EventManager.Models.DataLayer
{
    public static class QueryExtensions
    {
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, 
            int pageNum, int pageSize) where T : class
        {
            return query
                .Skip((pageNum -1) * pageSize)
                .Take(pageSize);
        }
    }
}
