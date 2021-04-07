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
    public class ProductosController : ControllerBase
    {
        public ProductosController(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetAsync()
        {
            ProductosDA productoDA = new ProductosDA(Context);
            return await productoDA.GetProductosAsync().ConfigureAwait(false);
        }

        [HttpGet("{id}", Name = "GetProducto")]
        public async Task<ActionResult<Producto>> GetAsync(int id)
        {
            ProductosDA productoDA = new ProductosDA(Context);
            var producto = await productoDA.GetProductoByIdAsync(id: id).ConfigureAwait(false);
            if (producto == null)
                return NotFound();
            return producto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Producto producto)
        {
            ProductosDA productoDA = new ProductosDA(Context);
            if (await productoDA.AddProductoAsync(producto).ConfigureAwait(false))
                return new CreatedAtRouteResult("GetProducto", new { id = producto.Id }, producto);
            return BadRequest();
        }
    }
}
