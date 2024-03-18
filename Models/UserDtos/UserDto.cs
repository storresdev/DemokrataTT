using System.ComponentModel.DataAnnotations;

namespace DemokrataTT.Models.UserDtos
{
    /// <summary>
    /// Dro de usuario para consultas
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Primer nombre
        /// </summary>
        [Required, MaxLength(50)]
        public required string FirstName { get; set; }

        /// <summary>
        /// Segundo Nombre
        /// </summary>
        [MaxLength(50)]
        public string? SecondName { get; set; }

        /// <summary>
        /// Primer apellido
        /// </summary>
        [Required, MaxLength(50)]
        public required string LastName { get; set; }

        /// <summary>
        /// Segundo apellido
        /// </summary>
        [MaxLength(50)]
        public string? SecondSurName { get; set; }

        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        [Required]
        public required DateTime BirdDate { get; set; }

        /// <summary>
        /// Salario
        /// </summary>
        [Required]
        public required int Salary { get; set; }

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
