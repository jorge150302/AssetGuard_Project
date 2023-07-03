using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetGuard_Project.Models;

public partial class Departamento
{
    [Key]
    [Required]
    public int IdDepartamento { get; set; }

    [Display(Name = "Descripción")]
    [Required(ErrorMessage = "Debe ingresar una descripción")]
    [StringLength(50)]
    public string? DescripcionDepartamento { get; set; }

    [Display(Name = "Estado")]
    public string? EstadoDepartamento { get; set; }

    public virtual ICollection<ActivosFijo> ActivosFijos { get; set; } = new List<ActivosFijo>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
