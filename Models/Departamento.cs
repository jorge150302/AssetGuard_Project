using System;
using System.Collections.Generic;

namespace AssetGuard_Project.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string? DescripcionDepartamento { get; set; }

    public string? EstadoDepartamento { get; set; }

    public virtual ICollection<ActivosFijo> ActivosFijos { get; set; } = new List<ActivosFijo>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
