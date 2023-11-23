using Microsoft.EntityFrameworkCore;
using API_SQLServer.Entities;

namespace API_SQLServer.Context
{
    // Classe responsável por acessar o DB
    public class ABCIncContext : DbContext
    {
        // Recebe a conexão com o DB e transfere para a classe base que inicia a conexão
        public ABCIncContext(DbContextOptions<ABCIncContext> options) : base(options)
        {}

        // Entidades DbSet -> classe no programa e uma tabela no DB
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Cargos> Cargos { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
    }
}
