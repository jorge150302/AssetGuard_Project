using System;
using System.Collections.Generic;

namespace AssetGuard_Project.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? NombreEmpleado { get; set; }

    public string? CedulaEmpleado { get; set; }

    public int? DepartamentoEmpleado { get; set; }

    public string? TipoPersonaEmpleado { get; set; }

    public DateTime? FechaIngresoEmpleado { get; set; }

    public string? EstadoEmpleado { get; set; }

    public virtual Departamento? DepartamentoEmpleadoNavigation { get; set; }
}
