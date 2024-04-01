using System.ComponentModel.DataAnnotations;

namespace Proyecto_Venta_Autos.Models
{
    public class Auto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public int Anio { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public bool Disponible { get; set; }
    }
}
