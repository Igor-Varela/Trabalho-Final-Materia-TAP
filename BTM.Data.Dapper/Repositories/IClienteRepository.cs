using BTM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTM.Data.Dapper.Repositories
{
     public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteDetails(int id);
        Task<bool> InsertCliente(Cliente cliente);
        Task<bool> UpdateCliente(Cliente cliente);
        Task<bool> DeleteCliente(int id);
        Task<Cliente> Where(Func<object, object> p);
    }
}
