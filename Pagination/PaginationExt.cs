using System.Linq.Expressions;

namespace DemokrataTT.Pagination
{
    /// <summary>
    /// Extención para adicionar ordenamiento por propiedad o columna
    /// </summary>
    public static class PaginationExt
    {
        /// <summary>
        /// Método extención de IQueryable para ordenar por propiedad o culumna
        /// </summary>
        /// <typeparam name="T">Entidad</typeparam>
        /// <param name="queryable">Consulta</param>
        /// <param name="propertyOrFieldName">Propiedad o columna sobre la cual ordenar</param>
        /// <param name="ascending">Dirección de ordenamiento</param>
        /// <returns>Método extención</returns>
        public static IQueryable<T> OrderByPropertyOrField<T>(
            this IQueryable<T> queryable, string propertyOrFieldName, bool ascending = true)
        {
            var elementType = typeof(T);
            var orderByMethodName = ascending ? "OrderBy" : "OrderByDescending";

            var parameterExpression = Expression.Parameter(elementType);
            var propertyOrFieldExpression = Expression.PropertyOrField(parameterExpression, propertyOrFieldName);

            var selector = Expression.Lambda(propertyOrFieldExpression, parameterExpression);

            var orderByExpression = Expression.Call(typeof(Queryable), orderByMethodName,
                [elementType, propertyOrFieldExpression.Type], queryable.Expression, selector);

            return queryable.Provider.CreateQuery<T>(orderByExpression);
        }
    }
}
