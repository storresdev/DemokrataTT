namespace DemokrataTT.Pagination
{
    /// <summary>
    /// Objeto resultado de la páginación
    /// </summary>
    /// <typeparam name="T">Entidad</typeparam>
    public class PaginationResult<T>
    {
        /// <summary>
        /// Número de paginas
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Tamaño de página
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Número total de páginas
        /// </summary>
        public int TotalNumberOfPages { get; set; }

        /// <summary>
        /// Número total de registros
        /// </summary>
        public int TotalNumberOfRecords { get; set; }

        /// <summary>
        /// Lista de resultados
        /// </summary>
        public List<T> Result { get; set; } = [];
    }
}
