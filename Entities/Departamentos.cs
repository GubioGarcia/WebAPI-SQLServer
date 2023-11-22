using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_SQLServer.Entities
{
    public class Departamentos
    {
        [Column("departamento_id")]
        [Key]
        public int DepartamentoId { get; set; }

        [Column("nome")]
        public string Nome { get; set; }
    }
}