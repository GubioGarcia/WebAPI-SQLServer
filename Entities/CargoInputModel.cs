using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SQLServer.Entities
{
    public class CargoInputModel
    {
        [Required]
        [Key]
        public int CargoId { get; set; }

        [Required]
        public int DepartamentoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int Salario { get; set; }
    }
}