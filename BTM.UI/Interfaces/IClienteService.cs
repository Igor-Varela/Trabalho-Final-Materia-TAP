using BTM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTM.UI.Interfaces
{
    interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        
        Task<Cliente> GetDetails(int id);
        
        Task<bool> DeleteCliente(int id);
       
        Task<bool> SaveCliente(Cliente cliente);



    }
}
