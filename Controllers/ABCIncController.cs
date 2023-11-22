using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using API_SQLServer.Context;
using API_SQLServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_SQLServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ABCIncController : ControllerBase
    {
        private readonly ABCIncContext _context;

        public ABCIncController(ABCIncContext context)
        {
            _context = context;
        }

        // Criar
        [HttpPost("CriarCargo")]
        public IActionResult CriarCargo(Cargos cargo)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Cargos (departamento_id, nome, salario) VALUES (@DepartamentoId, @Nome, @Salario);";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@DepartamentoId", cargo.DepartamentoId);
                    command.Parameters.AddWithValue("@Nome", cargo.Nome);
                    command.Parameters.AddWithValue("@Salario", cargo.Salario);
                    command.ExecuteNonQuery();
                }
            }
            return Ok(cargo);
        }

        [HttpPost("CriarDepartamento")]
        public IActionResult CriarDepartamento(Departamentos departamento)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Departamentos (nome) VALUES (@Nome);";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", departamento.Nome);
                    command.ExecuteNonQuery();
                }
            }
            return Ok(departamento);
        }

        [HttpPost("CriarFuncionario")]
        public IActionResult CriarFuncionario(Funcionarios funcionario)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Funcionarios (nome, data_contratacao, email, cargo_id) VALUES (@Nome, @DataContratacao, @Email, @CargoId);";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    command.Parameters.AddWithValue("@DataContratacao", funcionario.DataContratacao);
                    command.Parameters.AddWithValue("@Email", funcionario.Email);
                    command.Parameters.AddWithValue("@CargoId", funcionario.CargoId);
                    command.ExecuteNonQuery();
                }
            }
            return Ok(funcionario);
        }

        // Deletar
        [HttpDelete("DeletarCargo/{id}")]
        public IActionResult DeletarCargo(int id)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Cargos WHERE cargo_id = @CargoId;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CargoId", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) return NotFound();
                }
            }
            return NoContent();
        }

        [HttpDelete("DeletarDepartamento/{id}")]
        public IActionResult DeletarDepartamento(int id)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Departamentos WHERE departamento_id = @DepartamentoId;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@DepartamentoId", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) return NotFound();
                }
            }
            return NoContent();
        }

        [HttpDelete("DeletarFuncionario/{id}")]
        public IActionResult DeletarFuncionario(int id)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Funcionarios WHERE funcionario_id = @FuncionarioId;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@FuncionarioId", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) return NotFound();
                }
            }
            return NoContent();
        }

        // Atualizar
        [HttpPut("AtualizarCargo/{id}")]
        public IActionResult AtualizarCargo(int id, Cargos cargo)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "UPDATE Cargos SET departamento_id = @DepartamentoId, nome = @Nome, salario = @Salario WHERE cargo_id = @CargoId;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CargoId", id);
                    command.Parameters.AddWithValue("@DepartamentoId", cargo.DepartamentoId);
                    command.Parameters.AddWithValue("@Nome", cargo.Nome);
                    command.Parameters.AddWithValue("@Salario", cargo.Salario);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) return NotFound();
                }
            }
            return Ok(cargo);
        }

        [HttpPut("AtualizarDepartamento/{id}")]
        public IActionResult AtualizarDepartamento(int id, Departamentos departamento)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "UPDATE Departamentos SET nome = @Nome WHERE departamento_id = @DepartamentoId;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@DepartamentoId", id);
                    command.Parameters.AddWithValue("@Nome", departamento.Nome);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) return NotFound();
                }
            }
            return Ok(departamento);
        }

        [HttpPut("AtualizarFuncionario/{id}")]
        public IActionResult AtualizarFuncionario(int id, Funcionarios funcionario)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "UPDATE Funcionarios SET nome = @Nome, data_contratacao = @DataContratacao, email = @Email, cargo_id = @CargoId WHERE funcionario_id = @FuncionarioId;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@FuncionarioId", id);
                    command.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    command.Parameters.AddWithValue("@DataContratacao", funcionario.DataContratacao);
                    command.Parameters.AddWithValue("@Email", funcionario.Email);
                    command.Parameters.AddWithValue("@CargoId", funcionario.CargoId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) return NotFound();
                }
            }
            return Ok(funcionario);
        }

        // Obter
        [HttpGet("ObterCargo/{id}")]
        public IActionResult ObterCargoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Cargos WHERE cargo_id = @CargoId;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CargoId", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Cargos cargo = new Cargos
                            {
                                CargoId = (int)reader["cargo_id"],
                                DepartamentoId = (int)reader["departamento_id"],
                                Nome = (string)reader["nome"],
                                Salario = (int)reader["salario"]
                            };
                            return Ok(cargo);
                        }
                        else return NotFound();
                    }
                }
            }
        }

        [HttpGet("ObterDepartamento/{id}")]
        public IActionResult ObterDepartamentoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Departamentos WHERE departamento_id = @DepartamentoId;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@DepartamentoId", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Departamentos departamento = new Departamentos
                            {
                                DepartamentoId = (int)reader["departamento_id"],
                                Nome = (string)reader["nome"]
                            };
                            return Ok(departamento);
                        }
                        else return NotFound();
                    }
                }
            }
        }

        [HttpGet("ObterFuncionario/{id}")]
        public IActionResult ObterFuncionarioPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Funcionarios WHERE funcionario_id = @FuncionarioId;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@FuncionarioId", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Funcionarios funcionario = new Funcionarios
                            {
                                FuncionarioId = (int)reader["funcionario_id"],
                                Nome = (string)reader["nome"],
                                DataContratacao = (DateTime)reader["data_contratacao"],
                                Email = (string)reader["email"],
                                CargoId = (int)reader["cargo_id"]
                            };
                            return Ok(funcionario);
                        }
                        else return NotFound();
                    }
                }
            }
        }

        // Buscar por Nome
        [HttpGet("ObterCargoPorNome")]
        public IActionResult ObterCargoPorNome(string nome)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Cargos WHERE nome LIKE @Nome;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", "%" + nome + "%");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Cargos> cargos = new List<Cargos>();
                        while (reader.Read())
                        {
                            Cargos cargo = new Cargos
                            {
                                CargoId = (int)reader["cargo_id"],
                                DepartamentoId = (int)reader["departamento_id"],
                                Nome = (string)reader["nome"],
                                Salario = (int)reader["salario"]
                            };
                            cargos.Add(cargo);
                        }
                        return Ok(cargos);
                    }
                }
            }
        }

        [HttpGet("ObterDepartamentoPorNome")]
        public IActionResult ObterDepartamentoPorNome(string nome)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Departamentos WHERE nome LIKE @Nome;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", "%" + nome + "%");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Departamentos> departamentos = new List<Departamentos>();
                        while (reader.Read())
                        {
                            Departamentos departamento = new Departamentos
                            {
                                DepartamentoId = (int)reader["departamento_id"],
                                Nome = (string)reader["nome"]
                            };
                            departamentos.Add(departamento);
                        }
                        return Ok(departamentos);
                    }
                }
            }
        }

        [HttpGet("ObterFuncionarioPorNome")]
        public IActionResult ObterFuncionarioPorNome(string nome)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Funcionarios WHERE nome LIKE @Nome;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", "%" + nome + "%");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Funcionarios> funcionarios = new List<Funcionarios>();
                        while (reader.Read())
                        {
                            Funcionarios funcionario = new Funcionarios
                            {
                                FuncionarioId = (int)reader["funcionario_id"],
                                Nome = (string)reader["nome"],
                                DataContratacao = (DateTime)reader["data_contratacao"],
                                Email = (string)reader["email"],
                                CargoId = (int)reader["cargo_id"]
                            };
                            funcionarios.Add(funcionario);
                        }
                        return Ok(funcionarios);
                    }
                }
            }
        }

        [HttpGet("ObterCargoPorSalario")]
        public IActionResult ObterCargoPorSalario(int salario)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Cargos WHERE salario > @Salario;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Salario", salario);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Cargos> cargos = new List<Cargos>();
                        while (reader.Read())
                        {
                            Cargos cargo = new Cargos
                            {
                                CargoId = (int)reader["cargo_id"],
                                DepartamentoId = (int)reader["departamento_id"],
                                Nome = (string)reader["nome"],
                                Salario = (int)reader["salario"]
                            };
                            cargos.Add(cargo);
                        }

                        if (cargos.Count > 0) return Ok(cargos);
                        else return NotFound();
                    }
                }
            }
        }
    }
}
