using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ElCliente.DAL.DBContext;
using ElCliente.DAL.Repositorios.Contrato;
using Microsoft.EntityFrameworkCore;

namespace ElCliente.DAL.Repositorios
{
    public class RepositorioGenerico<TModel> : IRepositorioGenerico<TModel> where TModel : class
    {
        private readonly ElClienteContext _dbclienteContext;

        public RepositorioGenerico(ElClienteContext dbventaContext)
        {
            _dbclienteContext = dbventaContext;
        }

        public async Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null)
        {
            try
            {
                IQueryable<TModel> queryModelo = filtro == null ? _dbclienteContext.Set<TModel>() : _dbclienteContext.Set<TModel>().Where(filtro);
                return queryModelo;
            }
            catch (Exception)
            {

                throw;
            }
        }
//        public async Task<IQueryable<TModel>> Consultar(
//            Expression<Func<TModel, bool>> filtro = null,
//            params Expression<Func<TModel, object>>[] includes
//)
//        {
//            IQueryable<TModel> query = _dbclienteContext.Set<TModel>();

//            if (filtro != null)
//                query = query.Where(filtro);

//            if (includes != null)
//            {
//                foreach (var include in includes)
//                {
//                    query = query.Include(include);
//                }
//            }

//            return query;
//        }



        public async Task<TModel> Crear(TModel modelo)
        {
            try
            {
                _dbclienteContext.Set<TModel>().Add(modelo);
                await _dbclienteContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Editar(TModel modelo)
        {
            try
            {
                _dbclienteContext.Set<TModel>().Update(modelo);
                await _dbclienteContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Eliminar(TModel modelo)
        {
            try
            {
                _dbclienteContext.Set<TModel>().Remove(modelo);
                await _dbclienteContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro)
        {
            try
            {
                TModel modelo = await _dbclienteContext.Set<TModel>().FirstOrDefaultAsync(filtro);
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
