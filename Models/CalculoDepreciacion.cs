﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetGuard_Project.Models;

public partial class CalculoDepreciacion
{
  
    public int IdCd { get; set; }

    [Display(Name = "Año Proceso")]
    [Required(ErrorMessage = "Debe ingresar el Año")]
    [StringLength(4)]
    [Range(0, int.MaxValue, ErrorMessage = "Ingrese un Año en valor numerico")]
    public string? AnoProcesoCd { get; set; }

    [Display(Name = "Mes Proceso")]
    [Required(ErrorMessage = "Debe ingresar el Mes")]
    [StringLength(2)]
    [RegularExpression("([0-9]+)", ErrorMessage = "Ingrese un Mes en valor numerico")]
    public string? MesProcesoCd { get; set; }

    [Display(Name = "Activo Fijo")]
    public int? ActivoFijoCd { get; set; }

    [Display(Name = "Fecha del Proceso")]
    [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime? FechaProcesoCd { get; set; }

    [Display(Name = "Monto depreciado")]
    [Required(ErrorMessage = "Debe ingresar un monto depreciado")]
    [Range(0, double.MaxValue, ErrorMessage = "Ingrese un número positivo")]
    public decimal? MontoDepreciadoCd { get; set; }

    [Display(Name = "Depreciación acumulada")]
    [Required(ErrorMessage = "Debe ingresar la depreciación acumulada")]
    [Range(0, double.MaxValue, ErrorMessage = "Ingrese un número positivo")]
    public decimal? DepreciacionAcumuladaCd { get; set; }

    [Display(Name = "Cuenta Compra")]
    [Required(ErrorMessage = "Debe ingresar la Cuenta de Compra")]
    public int? CuentaCompra { get; set; }

    [Display(Name = "Cuenta Depreciación")]
    [Required(ErrorMessage = "Debe ingresar la Cuenta de Depreciación")]
    public int? CuentaDepreciacion { get; set; }
    [Display(Name = "Activo Fijo")]
    public virtual ActivosFijo? ActivoFijoCdNavigation { get; set; }
}
