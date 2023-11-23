using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SQLServer.Entities
{
    public class FuncionarioInputModel
    {
        [Required]
        [Key]
        public int FuncionarioId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime DataContratacao { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int CargoId { get; set; }
    }
}