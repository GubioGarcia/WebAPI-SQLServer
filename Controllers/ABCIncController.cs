using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_SQLServer.Context;
using API_SQLServer.Entities;

namespace API_SQLServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ABCIncController : ControllerBase
    {
        // Injeção de dependência -> recebe via construtor ABCIncContext, context que possibilita o acesso ao Db
        private readonly ABCIncContext _context; // atributo somente leitura

        public ABCIncController (ABCIncContext context) //Construtor
        {
            _context = context;
        }

    // Criar
        [HttpPost("CriarCargo")]
        public IActionResult CriarCargo (Cargos cargo)
        {
            _context.Add(cargo);
            _context.SaveChanges();
            return Ok(cargo);
        }

        [HttpPost("CriarDepartamento")]
        public IActionResult CriarDepartamento (Departamentos departamento)
        {
            _context.Add(departamento);
            _context.SaveChanges();
            return Ok(departamento);
        }
    
        [HttpPost("CriarFuncionario")]
        public IActionResult CriarFuncionario (Funcionarios funcionario)
        {
            _context.Add(funcionario);
            _context.SaveChanges();
            return Ok(funcionario);
        }

    // Deletar
        [HttpDelete("DeletarCargo{id}")]
        public IActionResult DeletarCargo (int id)
        {
            var cargoDb = _context.Cargos.Find(id);
            if (cargoDb == null) return NotFound();

            _context.Cargos.Remove(cargoDb);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("DeletarDepartamento{id}")]
        public IActionResult DeletarDepartamento (int id)
        {
            var departamentoDb = _context.Departamentos.Find(id);
            if (departamentoDb == null) return NotFound();

            _context.Departamentos.Remove(departamentoDb);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("DeletarFuncionario{id}")]
        public IActionResult DeletarFuncionario (int id)
        {
            var funcionarioDb = _context.Cargos.Find(id);
            if (funcionarioDb == null) return NotFound();

            _context.Cargos.Remove(funcionarioDb);
            _context.SaveChanges();
            return NoContent();
        }

    // Atualizar
        [HttpPut("AtualizarCargo{id}")]
        public IActionResult AtualizarCargo (int id, Cargos cargo)
        {
            var cargoDb = _context.Cargos.Find(id);
            if (cargoDb == null) return NotFound(); // Verificar se cargo é válido

            // Atualiza a propriedade no Db pela requisição
            cargoDb.DepartamentoId = cargo.DepartamentoId;
            cargoDb.Nome = cargo.Nome;
            cargoDb.salario = cargo.salario;

            _context.Cargos.Update(cargoDb);
            _context.SaveChanges();

            return Ok(cargoDb);
        }

        [HttpPut("AtualizarDepartamento{id}")]
        public IActionResult AtualizarDepartamento (int id, Departamentos departamento)
        {
            var departamentoDb = _context.Departamentos.Find(id);
            if (departamentoDb == null) return NotFound();

            // Atualiza a propriedade no Db pela requisição
            departamentoDb.Nome = departamento.Nome;

            _context.Departamentos.Update(departamentoDb);
            _context.SaveChanges();

            return Ok(departamentoDb);
        }

        [HttpPut("AtualizarFuncionario{id}")]
        public IActionResult AtualizarFuncionario (int id, Funcionarios funcionario)
        {
            var funcionarioDb = _context.Funcionarios.Find(id);
            if (funcionarioDb == null) return NotFound();

            // Atualiza a propriedade no Db pela requisição
            funcionarioDb.Nome = funcionario.Nome;
            funcionarioDb.DataContratacao = funcionario.DataContratacao;
            funcionarioDb.Email = funcionario.Email;
            funcionarioDb.CargoId = funcionario.CargoId;

            _context.Funcionarios.Update(funcionarioDb);
            _context.SaveChanges();

            return Ok(funcionarioDb);
        }

    // Buscar por ID
        [HttpGet("ObterCargo{id}")]
        public IActionResult ObterCargoId (int id)
        {
            var cargo = _context.Cargos.Find(id);
            if (cargo == null) return NotFound();
            return Ok(cargo);
        }

        [HttpGet("ObterDepartamento{id}")]
        public IActionResult ObterDepartamentoId (int id)
        {
            var departamento = _context.Departamentos.Find(id);
            if (departamento == null) return NotFound();
            return Ok(departamento);
        }

        [HttpGet("ObterFuncionario{id}")]
        public IActionResult ObterFuncionarioId (int id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            if (funcionario == null) return NotFound();
            return Ok(funcionario);
        }

    // Buscar por Nome
        [HttpGet("ObterCargoPorNome")]
        public IActionResult ObterCargoPorNome (string nome)
        {
            var cargo = _context.Cargos.Where(x => x.Nome.Contains(nome));
            if (cargo == null) return NotFound();
            return Ok(cargo);
        }

        [HttpGet("ObterDepartamentoPorNome")]
        public IActionResult ObterDepartamentoPorNome (string nome)
        {
            var departamento = _context.Departamentos.Where(x => x.Nome.Contains(nome));
            if (departamento == null) return NotFound();
            return Ok(departamento);
        }

        [HttpGet("ObterFuncionarioPorNome")]
        public IActionResult ObterFuncionarioPorNome (string nome)
        {
            var funcionario = _context.Funcionarios.Where(x => x.Nome.Contains(nome));
            if (funcionario == null) return NotFound();
            return Ok(funcionario);
        }

        [HttpGet("ObterCargoPorSalario")]
        public IActionResult ObterCargoPorSalario(int salario)
        {
            var cargo = _context.Cargos.Where(c => c.salario > salario).ToList();
            if (cargo == null || cargo.Count == 0) return NotFound();
            return Ok(cargo);
        }
    }
}