using System.ComponentModel.DataAnnotations;

namespace DemokrataTT.Models.Entities
{
    /// <summary>
    /// Entidad User
    /// </summary>
    public class User
    {
        /// <summary>
        /// Identificador de Usuario
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Primer nombre
        /// </summary>
        [MaxLength(50)]
        public required string FirstName { get; set; }

        /// <summary>
        /// Segundo nombre
        /// </summary>
        [MaxLength(50)]
        public string? SecondName { get; set; }

        /// <summary>
        /// Primer apellido
        /// </summary>
        [MaxLength(50)]
        public required string LastName { get; set; }

        /// <summary>
        /// Segundo apellido
        /// </summary>
        [MaxLength(50)]
        public string? SecondSurName { get; set; }

        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        public required DateTime BirdDate { get; set; }

        /// <summary>
        /// Sueldo
        /// </summary>
        public int Salary { get; set; }

        /// <summary>
        /// Fecha de creación del registro
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Fecha de modificación del registro
        /// </summary>
        public DateTime ModificationDate { get; set; }
    }
}
