using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_SQLServer.Entities
{
    public class Funcionarios
    {
        [Column("funcionario_id")]
        [Required]
        [Key]
        public int FuncionarioId { get; set; }

        [Column("nome")]
        [Required]
        public string Nome { get; set; }

        [Column("data_contratacao")]
        [Required]
        public DateTime DataContratacao { get; set; }

        [Column("email")]
        [Required]
        public string Email { get; set; }

        [Column("cargo_id")]
        [Required]
        public int CargoId { get; set; }

        // Propriedade de navegação para o relacionamento com Cargos
        public Cargos Cargo { get; set; }
    }
}
