using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionEntidades.Entities
{
    public class Factura
    {
        [Required]
        public string Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        [Required]
        public long ClienteId { get; set; }
    }
}
