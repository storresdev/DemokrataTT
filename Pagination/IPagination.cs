namespace DemokrataTT.Pagination
{
    /// <summary>
    /// Interfaz del servicio de paginación
    /// </summary>
    public interface IPagination
    {
        Task<PaginationResult<T>> CreatePagedGenericResult<T>(
            IQueryable<T> queryable,
            int page,
            int pageSize,
            string orderBy,
            bool ascending
            );
    }
}
