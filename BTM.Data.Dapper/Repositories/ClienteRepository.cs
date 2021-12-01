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
    public class ClienteRepository : IClienteRepository

    {
        private string ConnectionString;

        public ClienteRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public async Task<bool> DeleteCliente(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM Clientes WHERE Id_Cliente = @Id_Cliente";

            var result = await db.ExecuteAsync(sql.ToString(), new { Id_Cliente = id });

            return result > 0;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            var db = dbConnection();
            var sql = @" SELECT Id_Cliente, NomeC, EmpresaC, EnderecoC, CidadeC, EmailC, CpfC, TelefoneC, EstadoC FROM [dbo].[Clientes]
                        ";
            return await db.QueryAsync<Cliente>(sql.ToString(), new { });
        }

        public async Task<Cliente> GetClienteDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT Id_Cliente, NomeC, EmpresaC, EnderecoC, CidadeC, EmailC, CpfC, TelefoneC, EstadoC FROM [dbo].[Clientes]
                       WHERE Id_Cliente = @Id_Cliente ";

            return await db.QueryFirstOrDefaultAsync<Cliente>(sql.ToString(), new { Id_Cliente = id });
        }

        public async Task<bool> InsertCliente(Cliente cliente)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO Clientes (NomeC, EmpresaC, EnderecoC, CidadeC, EmailC, CpfC, TelefoneC, EstadoC)
                        VALUES(@NomeC, @EmpresaC, @EnderecoC, @CidadeC, @EmailC, @CpfC, @TelefoneC, @EstadoC)";


            var result = await db.ExecuteAsync(sql.ToString(),
                new { cliente.NomeC, cliente.EmpresaC, cliente.EnderecoC, cliente.CidadeC, cliente.EmailC, cliente.CpfC, cliente.TelefoneC, cliente.EstadoC });

                return result > 0;
        }

        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            var db = dbConnection();
            var sql = @"UPDATE Clientes
                        SET NomeC = @NomeC, EmpresaC = @EmpresaC, EnderecoC = @EnderecoC, CidadeC = @CidadeC, EmailC =@EmailC, CpfC = @CpfC, TelefoneC = @TelefoneC, EstadoC = @EstadoC
                        WHERE Id_Cliente = @Id_Cliente ";

            var result = await db.ExecuteAsync(sql.ToString(),
                new { cliente.NomeC, cliente.EmpresaC, cliente.EnderecoC, cliente.CidadeC, cliente.EmailC, cliente.CpfC, cliente.TelefoneC, cliente.EstadoC, cliente.Id_Cliente });

            return result > 0;
        }

        public Task<Cliente> Where(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
