using FacturacionDatos.Context;
using FacturacionEntidades;
using FacturacionEntidades.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;

namespace FacturacionDatos
{
    public class FacturasDA
    {
        public FacturasDA(ApplicationDbContext context) 
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        public Task<List<Factura>> GetFacturasAsync()
        {
            try
            {
                return Task.Run( () => { return Context.Facturas.ToList(); });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Factura> GetFacturaByIdAsync(string id)
        {
            try
            {
                return Task.Run(() => { return Context.Facturas.FirstOrDefault(db => db.Id == id); });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddFacturaAsync(Factura factura)
        {
            try
            {
                Context.Facturas.Add(factura);
                await Context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateFacturaAsync(Factura factura)
        {
            try
            {
                Context.Entry(factura).State = EntityState.Modified;
                await Context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteFacturaAsync(string id)
        {
            try
            {
                var factura = await Context.Facturas.FirstOrDefaultAsync(db => db.Id == id);
                if (factura == null)
                    return false;
                Context.Facturas.Remove(factura);
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
