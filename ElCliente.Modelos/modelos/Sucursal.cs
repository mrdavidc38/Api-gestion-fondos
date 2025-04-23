using System;
using System.Collections.Generic;

namespace ElCliente.DAL.DBContext;

public partial class Sucursal
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public virtual ICollection<Visitan> Visitans { get; set; } = new List<Visitan>();

    public virtual ICollection<Producto> IdProductos { get; set; } = new List<Producto>();
}
