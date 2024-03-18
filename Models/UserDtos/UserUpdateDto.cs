using System.ComponentModel.DataAnnotations;

namespace DemokrataTT.Models.UserDtos
{
    /// <summary>
    /// DTO de Usuario para edicion
    /// </summary>
    public class UserUpdateDto
    {
        /// <summary>
        /// Identificador de usuario
        /// </summary>
        [Required]
        public required int Id { get; set; }

        /// <summary>
        /// Primer nombre
        /// </summary>
        [Required, MaxLength(50), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "No se permiten números")]
        public required string FirstName { get; set; }

        /// <summary>
        /// Segundo nombre
        /// </summary>
        [MaxLength(50), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "No se permiten números")]
        public string? SecondName { get; set; }

        /// <summary>
        /// Primer apellido
        /// </summary>
        [Required, MaxLength(50), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "No se permiten números")]
        public required string LastName { get; set; }

        /// <summary>
        /// Segundo apellido
        /// </summary>
        [MaxLength(50), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "No se permiten números")]
        public string? SecondSurName { get; set; }

        /// <summary>
        /// Fecha de cumpleaños
        /// </summary>
        [Required]
        public required DateTime BirdDate { get; set; }

        /// <summary>
        /// Salario
        /// </summary>
        [Required, DeniedValues(0, ErrorMessage = "El salario no puede ser 0")]
        public required int Salary { get; set; }
    }
}
