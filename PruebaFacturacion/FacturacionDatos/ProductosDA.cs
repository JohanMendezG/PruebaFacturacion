using FacturacionDatos.Context;
using FacturacionEntidades.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionDatos
{
    public class ProductosDA
    {
        public ProductosDA(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        public Task<List<Producto>> GetProductosAsync()
        {
            try
            {
                return Task.Run(() => { return Context.Productos.ToList(); });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Producto> GetProductoByIdAsync(int id)
        {
            try
            {
                return Task.Run(() => { return Context.Productos.FirstOrDefault(db => db.Id == id); });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddProductoAsync(Producto producto)
        {
            try
            {
                Context.Productos.Add(producto);
                await Context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateProductAsync(Producto producto)
        {
            try
            {
                Context.Entry(producto).State = EntityState.Modified;
                await Context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteProductoAsync(int id)
        {
            try
            {
                var producto = await Context.Productos.FirstOrDefaultAsync(db => db.Id == id);
                if (producto == null)
                    return false;
                Context.Productos.Remove(producto);
                await Context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
