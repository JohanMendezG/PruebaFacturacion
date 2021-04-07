using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionEntidades.Entities
{
    public class Cliente
    {
        [Key]
        [Required]
        public long Documento { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombres { get; set; }
        [Required]
        [MaxLength(20)]
        public string PrimerApellido { get; set; }
        [Required]
        [MaxLength(20)]
        public string SegundoApellido { get; set; }
        [Required]
        public int Edad { get; set; }
    }
}
