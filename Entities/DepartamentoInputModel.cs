using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SQLServer.Entities
{
    public class DepartamentoInputModel
    {
        [Required]
        [Key]
        public int DepartamentoId { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}