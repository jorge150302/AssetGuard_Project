using System;
using System.Collections.Generic;

namespace AssetGuard_Project.Models;

public partial class ActivosFijo
{
    public int IdAf { get; set; }

    public string? DescripcionAf { get; set; }

    public int? DepartamentoAf { get; set; }

    public int? TipoActivoAf { get; set; }

    public DateTime? FechaRegistroAf { get; set; }

    public decimal? ValorCompraAf { get; set; }

    public decimal? DepreciacionAcumuladaAf { get; set; }

    public virtual ICollection<CalculoDepreciacion> CalculoDepreciacions { get; set; } = new List<CalculoDepreciacion>();

    public virtual Departamento? DepartamentoAfNavigation { get; set; }

    public virtual TiposActivo? TipoActivoAfNavigation { get; set; }
}
