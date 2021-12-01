using BTM.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTM.Data.Dapper.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private string ConnectionString;

        public FuncionarioRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public async Task<bool> DeleteFuncionario(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM Funcionarios WHERE Id = @Id ";

            var result = await db.ExecuteAsync(sql.ToString(), new { Id = id });
            return result > 0;
        }

        public async Task<IEnumerable<Funcionario>> GetAllFuncionarios()
        {
            var db = dbConnection();

            var sql = @" SELECT Id, Nome, Endereco, Cpf, Telefone, Cidade, Estado, Cargo, Area, Email FROM [dbo].[Funcionarios]";

            return await db.QueryAsync<Funcionario>(sql.ToString(), new { });

        }

        public async Task<Funcionario> GetFuncionarioDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT Id, Nome, Endereco, Cpf, Telefone, Cidade, Estado, Cargo, Area, Email FROM [dbo].[Funcionarios] WHERE Id = @Id ";

            return await db.QueryFirstOrDefaultAsync<Funcionario>(sql.ToString(), new { Id = id });
        }

        public async Task<bool> InsertFuncionario(Funcionario funcionario)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO Funcionarios(Nome, Endereco, Cpf, Telefone, Cidade, Estado, Cargo, Area, Email)
                        VALUES(@Nome, @Endereco, @Cpf, @Telefone, @Cidade, @Estado, @Cargo, @Area, @Email)";


            var result = await db.ExecuteAsync(sql.ToString(),
                new { funcionario.Nome, funcionario.Endereco, funcionario.Cpf, funcionario.Telefone, funcionario.Cidade, funcionario.Estado, funcionario.Cargo, funcionario.Area, funcionario.Email });

            return result > 0;
        }

        public async Task<bool> UpdateFuncionario(Funcionario funcionario)
        {
            var db = dbConnection();
            var sql = @"UPDATE Funcionarios
                        SET Nome = @Nome ,Endereco = @Endereco, Cpf = @Cpf, Telefone = @Telefone, Cidade = @Cidade, Estado = @Estado, Cargo = @Cargo, Area = @Area, Email = @Email
                        WHERE Id = @Id ";

            var result = await db.ExecuteAsync(sql.ToString(),
                new { funcionario.Nome, funcionario.Endereco, funcionario.Cpf, funcionario.Telefone, funcionario.Cidade, funcionario.Estado, funcionario.Cargo, funcionario.Area, funcionario.Email, funcionario.Id });

            return result > 0;
        }
    }
}
