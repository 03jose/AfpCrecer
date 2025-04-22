using PruebaTecnica.Domain.Validators;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Domain.DTOs
{
    public class ProductoDTO
    {
        
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Nombre { get; set; }

        [StringLength(500, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(0.01, 1000000, ErrorMessage = "El campo {0} debe ser mayor que {1} y menor que {2}.")]
        public decimal Precio { get; set; }


        [Range(0.01, 100, ErrorMessage = "El campo {0} debe ser mayor que {1} y menor que {2}.")]
        [CustomValidation(typeof(DescuentosValidator), nameof(DescuentosValidator.DescuentoValidation))]        
        public decimal? PrecioDescuento { get; set; }

    }
}
