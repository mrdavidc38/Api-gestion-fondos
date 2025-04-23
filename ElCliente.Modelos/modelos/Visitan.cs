using System;
using System.Collections.Generic;

namespace ElCliente.DAL.DBContext;

public partial class Visitan
{
    public int IdSucursal { get; set; }

    public int IdCliente { get; set; }

    public DateOnly FechaVisita { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
