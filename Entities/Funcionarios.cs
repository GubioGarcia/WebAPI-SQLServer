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
        [Key]
        public int FuncionarioId { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("data_contratacao")]
        public DateTime DataContratacao { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("cargo_id")]
        [ForeignKey("CargoId")]
        public int CargoId { get; set; }

        // Propriedade de navegação para o relacionamento com Cargos
        public Cargos Cargo { get; set; }
    }
}
