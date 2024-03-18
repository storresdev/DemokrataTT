
using Microsoft.EntityFrameworkCore;

namespace DemokrataTT.Pagination
{
    /// <summary>
    /// Implementación del servicio de paginación
    /// </summary>
    public class Pagination : IPagination
    {
        /// <summary>
        /// Método para la creación de la paginación
        /// </summary>
        /// <typeparam name="T">entidad</typeparam>
        /// <param name="queryable">Consulta a paginar</param>
        /// <param name="page">Número de página</param>
        /// <param name="pageSize">Tamaño de página</param>
        /// <param name="orderBy">Caracteristica de ordenamiento</param>
        /// <param name="ascending">Identificador de ascendecia</param>
        /// <returns>Objeto del resutlado de la paginación</returns>
        public async Task<PaginationResult<T>> CreatePagedGenericResult<T>(
            IQueryable<T> queryable, int page, int pageSize, string orderBy, bool ascending)
        {
            var skiptAmount = pageSize * (page - 1);
            var totalNumberOfRecords = await queryable.CountAsync();

            var results = new List<T>();

            if (orderBy is null)
            {
                results = await queryable.Skip(skiptAmount).Take(pageSize).ToListAsync();
            }
            else
            {
                results = await queryable.OrderByPropertyOrField(orderBy, ascending).Skip(skiptAmount).Take(pageSize).ToListAsync();
            }

            var mod = totalNumberOfRecords % pageSize;
            var totalPageCount = (totalNumberOfRecords / pageSize) + (mod == 0 ? 0 : 1);

            return new PaginationResult<T>
            {
                Result = results,
                PageNumber = page,
                PageSize = pageSize,
                TotalNumberOfRecords = totalNumberOfRecords,
                TotalNumberOfPages = totalPageCount
            };
        }
    }
}
