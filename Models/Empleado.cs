using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetGuard_Project.Models;

public partial class Empleado
{
    [Key]
    [Required]
    public int IdEmpleado { get; set; }


    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "Debe ingresar un nombre")]
    [StringLength(50)]

    public string? NombreEmpleado { get; set; }

    [Display(Name = "Cédula")]
    [StringLength(11, ErrorMessage = "Mínimo permitido de 11 caracteres", MinimumLength = 11)]
    [Required(ErrorMessage = "La cédula es obligatoria")]
    public string? CedulaEmpleado { get; set; }

    [Display(Name = "Departamento")]
    public int? DepartamentoEmpleado { get; set; }

    [Display(Name = "Tipo de persona")]

    public string? TipoPersonaEmpleado { get; set; }

    [Display(Name = "Fecha de ingreso")]
    [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
    [DataType(DataType.DateTime)]
    public DateTime? FechaIngresoEmpleado { get; set; }

    [Display(Name = "Estado")]
    public string? EstadoEmpleado { get; set; }


    [Display(Name = "Departamento")]
    public virtual Departamento? DepartamentoEmpleadoNavigation { get; set; }

}
