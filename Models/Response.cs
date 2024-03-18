using System.Net;

namespace DemokrataTT.Models
{
    /// <summary>
    /// Modelo de respuesta generica para el API
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Código de estado
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Identificador de operación exitosa
        /// </summary>
        public bool IsSucces { get; set; } = true;

        /// <summary>
        /// Objeto con el resultado de la operación
        /// </summary>
        public object? Result { get; set; }

        /// <summary>
        /// Lista de errores de la operación
        /// </summary>
        public List<string>? ErrorsMessage { get; set; }
    }
}
