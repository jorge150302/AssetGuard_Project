using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetGuard_Project.Models;

public partial class ActivosFijo
{
    public int IdAf { get; set; }

    [Display(Name = "Descripción")]
    [Required(ErrorMessage = "Debe ingresar una descripción")]

    public string? DescripcionAf { get; set; }

    [Display(Name = "Departamento")]
    [Required(ErrorMessage = "Debe ingresar un departamento")]

    public int? DepartamentoAf { get; set; }

    [Display(Name = "Tipo de activo")]
    [Required(ErrorMessage = "Debe ingresar un tipo de activo")]

    public int? TipoActivoAf { get; set; }

    [Display(Name = "Fecha de registro")]
    [Required(ErrorMessage = "Debe ingresar una fecha de registro")]
    [DataType(DataType.Date)]
    public DateTime? FechaRegistroAf { get; set; }

    [Display(Name = "Valor de compra")]
    [Required(ErrorMessage = "Debe ingresar un valor de la compra")]
    [Range(0, double.MaxValue, ErrorMessage = "Ingrese un número positivo")]
    public decimal? ValorCompraAf { get; set; }

    [Display(Name = "Depreciación acumulada")]
    [Required(ErrorMessage = "Debe ingresar una depreciación acumulada")]

    public decimal? DepreciacionAcumuladaAf { get; set; }

    public virtual ICollection<CalculoDepreciacion> CalculoDepreciacions { get; set; } = new List<CalculoDepreciacion>();

    [Display(Name = "Departamento")]
    public virtual Departamento? DepartamentoAfNavigation { get; set; }

    [Display(Name = "Tipo de activo")]
    public virtual TiposActivo? TipoActivoAfNavigation { get; set; }
}
