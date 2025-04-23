using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ElCliente.BLL.Servicios.Contrato;
using ElCliente.DAL.Repositorios;
using ElCliente.DAL.Repositorios.Contrato;
using Microsoft.EntityFrameworkCore;

namespace ElCliente.BLL.Servicios
{
    public class Visitan : IVisitan
    {
        private readonly IRepositorioGenerico<Visitan> _visitanRepositorio;

        public Visitan(IRepositorioGenerico<Visitan> productoRepositorio)
        {
            _visitanRepositorio = productoRepositorio;
        }

        public async Task<List<Visitan>>? Consultar()
        {
            var queryVisitan = await _visitanRepositorio.Consultar();
            var listaVisitan = queryVisitan.ToList();

            return listaVisitan;
        }

        public Task<Visitan> Crear(Visitan modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(Visitan modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(Visitan modelo)
        {
            throw new NotImplementedException();
        }

        public Task<Visitan> Obtener(Expression<Func<Visitan, bool>> filtro)
        {
            throw new NotImplementedException();
        }
    }
}
