using System.ComponentModel.DataAnnotations;

namespace AssetGuard_Project.Models
{
    public class EnvioContabilidad
    {

        [Key]
        [Required]
        public int IdEC { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe ingresar una descripción")]
        [StringLength(50)]
        public string? DescripcionEC { get; set; }

        [Display(Name = "Auxiliar ")]
        public int? Auxiliar { get; set; }
        [Display(Name = "Cuenta Débito")]
        public int? CuentaDB { get; set; }
        
        [Display(Name = "Cuenta Crédito")] 
        public int? CuentaCR { get; set; }
        [Display(Name = "Monto")] 
        public int MontoEnvioContabilida { get; set; }



    }
}
