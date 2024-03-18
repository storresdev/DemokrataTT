namespace DemokrataTT.Pagination
{
    /// <summary>
    /// Parámetros para paginación.
    /// </summary>
    public class PaginationParams
    {
        /// <summary>
        /// Constante para el máximo de tamaño de página
        /// </summary>
        private const int MaxPageSize = 50;

        /// <summary>
        /// Número de páginas
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Identificador de tamaño de paginas para hacer el calculo total de tamaño
        /// </summary>
        private int _pageSize = 10;

        /// <summary>
        /// Tamaño calculado por página
        /// </summary>
        public int PageSize { get => _pageSize; set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }

        /// <summary>
        /// Identificador de ordenamiento
        /// </summary>
        public string? OrderBy { get; set; }

        /// <summary>
        /// Identificador de dirección de ordenamiento
        /// </summary>
        public bool OrderAsc { get; set; }
    }
}
