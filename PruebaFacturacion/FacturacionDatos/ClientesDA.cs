using FacturacionDatos.Context;
using FacturacionEntidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionDatos
{
    public class ClientesDA
    {
        public ClientesDA(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        public Task<List<Cliente>> GetClientesAsync()
        {
            try
            {
                return Task.Run(() => { return Context.Clientes.ToList(); });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
