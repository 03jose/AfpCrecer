using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Domain.Validators
{
    public static class DescuentosValidator
    {
        public static ValidationResult DescuentoValidation(decimal montoDescuento, ValidationContext context)
        {
            if (montoDescuento < 0)
            {
                return new ValidationResult("El monto del descuento no puede ser menor a cero");
            }
            
            else if (montoDescuento > 100)
            {
                return new ValidationResult("El monto del descuento no puede ser mayor al 100%");
            }


            return ValidationResult.Success;
        }
    }
}
