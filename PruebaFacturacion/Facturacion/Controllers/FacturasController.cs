using FacturacionDatos.Context;
using FacturacionEntidades.Entities;
using FacturacionDatos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        public FacturasController(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetAsync()
        {
            FacturasDA facturasDA = new FacturasDA(Context);
            return await facturasDA.GetFacturasAsync().ConfigureAwait(false);
        }

        [HttpGet("{id}", Name = "GetFactura")]
        public async Task<ActionResult<Factura>> GetAsync(string id)
        {
            FacturasDA facturasDA = new FacturasDA(Context);
            var factura = await facturasDA.GetFacturaByIdAsync(id: id).ConfigureAwait(false);
            if (factura == null)
                return NotFound();
            return factura;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Factura factura)
        {
            FacturasDA facturasDA = new FacturasDA(Context);
            if (await facturasDA.AddFacturaAsync(factura).ConfigureAwait(false))
                return new CreatedAtRouteResult("GetFactura", new { id = factura.Id }, factura);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(string id, [FromBody] Factura factura)
        {
            if (id != factura.Id)
                return BadRequest();
            FacturasDA facturasDA = new FacturasDA(Context);
            if (await facturasDA.UpdateFacturaAsync(factura: factura).ConfigureAwait(false))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            FacturasDA facturasDA = new FacturasDA(Context);
            if (await facturasDA.DeleteFacturaAsync(id: id).ConfigureAwait(false))
                return Ok();
            return NotFound();
        }
    }
}
