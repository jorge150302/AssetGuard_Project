using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AssetGuard_Project.Models;

public partial class TiposActivo
{
    public int IdTa { get; set; }
    [Display(Name = "Descripción")]
    [Required(ErrorMessage = "Debe ingresar una descripción")]


    public string? DescripcionTa { get; set; }
    [Display(Name = "Cuenta Contable Compra")]

    public int? CuentaContableCompraTa { get; set; }
    [Display(Name = "Cuenta Contable Depreciación")]

    public int? CuentaContableDepreciacionTa { get; set; }
    [Display(Name = "Estado")]

    public string? EstadoTa { get; set; }

    public virtual ICollection<ActivosFijo> ActivosFijos { get; set; } = new List<ActivosFijo>();
}
