using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionEntidades.Entities
{
    public class Producto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(10)]
        [RegularExpression("[0-9.]{1,10}")]
        public string PrecioUnidad { get; set; }
        [Required]
        public int CantInventario { get; set; }
    }
}
