using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Venta_Autos.Models
{
    public class Usuario00
    {

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese el nombre.")]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese el correo electrónico.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese la contraseña.")]
        [MaxLength(100)]
        public string Contraseña { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese el rol.")]
        [MaxLength(20)]
        [RegularExpression("^(Cliente|Administrador)$", ErrorMessage = "El rol debe ser 'Cliente' o 'Administrador'.")]
        public string Rol { get; set; }

    }
}
