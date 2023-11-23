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
        public IActionResult CriarCargo([FromBody] CargoInputModel cargoInput)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Cargos (departamento_id, nome, salario) VALUES (@DepartamentoId, @Nome, @Salario);";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@DepartamentoId", cargoInput.DepartamentoId);
                    command.Parameters.AddWithValue("@Nome", cargoInput.Nome);
                    command.Parameters.AddWithValue("@Salario", cargoInput.Salario);
                    command.ExecuteNonQuery();
                }
            }
            return Ok(cargoInput);
        }

        [HttpPost("CriarDepartamento")]
        public IActionResult CriarDepartamento([FromBody] DepartamentoInputModel departamentoInput)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Departamentos (nome) VALUES (@Nome);";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", departamentoInput.Nome);
                    command.ExecuteNonQuery();
                }
            }
            return Ok(departamentoInput);
        }

        [HttpPost("CriarFuncionario")]
        public IActionResult CriarFuncionario([FromBody] FuncionarioInputModel funcionarioInput)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Funcionarios (nome, data_contratacao, email, cargo_id) VALUES (@Nome, @DataContratacao, @Email, @CargoId);";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", funcionarioInput.Nome);
                    command.Parameters.AddWithValue("@DataContratacao", funcionarioInput.DataContratacao);
                    command.Parameters.AddWithValue("@Email", funcionarioInput.Email);
                    command.Parameters.AddWithValue("@CargoId", funcionarioInput.CargoId);
                    command.ExecuteNonQuery();
                }
            }
            return Ok(funcionarioInput);
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
        public IActionResult AtualizarCargo(int id, [FromBody] CargoInputModel cargoInput)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "UPDATE Cargos SET departamento_id = @DepartamentoId, nome = @Nome, salario = @Salario WHERE cargo_id = @CargoId;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CargoId", id);
                    command.Parameters.AddWithValue("@DepartamentoId", cargoInput.DepartamentoId);
                    command.Parameters.AddWithValue("@Nome", cargoInput.Nome);
                    command.Parameters.AddWithValue("@Salario", cargoInput.Salario);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) return NotFound();
                }
            }
            return Ok(cargoInput);
        }

        [HttpPut("AtualizarDepartamento/{id}")]
        public IActionResult AtualizarDepartamento(int id, [FromBody] DepartamentoInputModel departamentoInput)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "UPDATE Departamentos SET nome = @Nome WHERE departamento_id = @DepartamentoId;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@DepartamentoId", id);
                    command.Parameters.AddWithValue("@Nome", departamentoInput.Nome);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) return NotFound();
                }
            }
            return Ok(departamentoInput);
        }

        [HttpPut("AtualizarFuncionario/{id}")]
        public IActionResult AtualizarFuncionario(int id, [FromBody] FuncionarioInputModel funcionarioInput)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "UPDATE Funcionarios SET nome = @Nome, data_contratacao = @DataContratacao, email = @Email, cargo_id = @CargoId WHERE funcionario_id = @FuncionarioId;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@FuncionarioId", id);
                    command.Parameters.AddWithValue("@Nome", funcionarioInput.Nome);
                    command.Parameters.AddWithValue("@DataContratacao", funcionarioInput.DataContratacao);
                    command.Parameters.AddWithValue("@Email", funcionarioInput.Email);
                    command.Parameters.AddWithValue("@CargoId", funcionarioInput.CargoId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) return NotFound();
                }
            }
            return Ok(funcionarioInput);
        }

        // Obter
        [HttpGet("ListarCargos")]
        public IActionResult ListarCargos()
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Cargos;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
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

        [HttpGet("ListarDepartamentos")]
        public IActionResult ListarDepartamentos()
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Departamentos;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
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

        [HttpGet("ListarFuncionarios")]
        public IActionResult ListarFuncionarios()
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Funcionarios;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
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

        [HttpGet("ObterCargosPorSalario")]
        public IActionResult ObterCargosPorSalario(int salario)
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

        [HttpGet("ObterFuncionariosPorSalario")]
        public IActionResult ObterFuncionariosPorSalario(int salario)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Funcionarios INNER JOIN Cargos ON Funcionarios.cargo_id = Cargos.cargo_id WHERE Cargos.salario > @Salario;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Salario", salario);
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
                                CargoId = (int)reader["cargo_id"]
                                // Você pode adicionar mais propriedades conforme necessário
                            };
                            funcionarios.Add(funcionario);
                        }

                        if (funcionarios.Count > 0) return Ok(funcionarios);
                        else return NotFound();
                    }
                }
            }
        }

        [HttpGet("ListarFuncionariosPorCargo/{cargoId}")]
        public IActionResult ListarFuncionariosPorCargo(int cargoId)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Funcionarios WHERE cargo_id = @CargoId;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CargoId", cargoId);
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

        [HttpGet("ListarFuncionariosPorDepartamento/{departamentoId}")]
        public IActionResult ListarFuncionariosPorDepartamento(int departamentoId)
        {
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                string sql = "SELECT Funcionarios.* FROM Funcionarios INNER JOIN Cargos ON Funcionarios.cargo_id = Cargos.cargo_id WHERE Cargos.departamento_id = @DepartamentoId;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@DepartamentoId", departamentoId);
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
    }
}
