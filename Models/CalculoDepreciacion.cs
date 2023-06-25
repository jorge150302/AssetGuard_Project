using System;
using System.Collections.Generic;

namespace AssetGuard_Project.Models;

public partial class CalculoDepreciacion
{
    public int IdCd { get; set; }

    public string? AnoProcesoCd { get; set; }

    public string? MesProcesoCd { get; set; }

    public int? ActivoFijoCd { get; set; }

    public DateTime? FechaProcesoCd { get; set; }

    public decimal? MontoDepreciadoCd { get; set; }

    public decimal? DepreciacionAcumuladaCd { get; set; }

    public int? CuentaCompra { get; set; }

    public int? CuentaDepreciacion { get; set; }

    public virtual ActivosFijo? ActivoFijoCdNavigation { get; set; }
}
