using System;
using System.Collections.Generic;

namespace ElCliente.DAL.DBContext;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; } = null!;

    public string? TipoProducto { get; set; } = null!;
    public decimal? ProdMontoMinimo { get; set; }

    public virtual ICollection<Cliente>? IdClientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Sucursal>? IdSucursals { get; set; } = new List<Sucursal>();
}
