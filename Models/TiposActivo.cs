using System;
using System.Collections.Generic;

namespace AssetGuard_Project.Models;

public partial class TiposActivo
{
    public int IdTa { get; set; }

    public string? DescripcionTa { get; set; }

    public int? CuentaContableCompraTa { get; set; }

    public int? CuentaContableDepreciacionTa { get; set; }

    public string? EstadoTa { get; set; }

    public virtual ICollection<ActivosFijo> ActivosFijos { get; set; } = new List<ActivosFijo>();
}
