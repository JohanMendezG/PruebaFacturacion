using FacturacionDatos;
using FacturacionDatos.Context;
using FacturacionEntidades.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        public ClientesController(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAsync()
        {
            ClientesDA clientes = new ClientesDA(Context);
            return await clientes.GetClientesAsync().ConfigureAwait(false);
        }
    }
}
