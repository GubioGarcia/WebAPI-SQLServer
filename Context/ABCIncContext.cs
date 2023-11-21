using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_SQLServer.Entities;

namespace API_SQLServer.Context
{
    // Classe resposavel por acessar o DB
    public class ABCIncContext : DbContext
    {
        // Recebe a conexão com o DB e tranfere para a classe base que inicia a conexão
        public ABCIncContext(DbContextOptions<ABCIncContext> options) : base(options)
        {}

        // entidades DbSet -> classe no programa e uma tabela no DB
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Cargos> Cargos { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
    }
}