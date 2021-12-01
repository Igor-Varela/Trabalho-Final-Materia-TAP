using BTM.Data.Dapper.Repositories;
using BTM.Model;
using BTM.UI.Data;
using BTM.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTM.UI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly SqlConfiguration _configuration;
        private IClienteRepository _clienteRepository;

        public ClienteService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _clienteRepository = new ClienteRepository(configuration.ConnectionString);
        }


        public Task<bool> DeleteCliente(int id)
        {
            return _clienteRepository.DeleteCliente(id);
        }

        public Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return _clienteRepository.GetAllClientes();
        }

        public Task<Cliente> GetDetails(int id)
        {
            return _clienteRepository.GetClienteDetails(id);
        }

        public Task<bool> SaveCliente(Cliente cliente)
        {
            if (cliente.Id_Cliente == 0)
                return _clienteRepository.InsertCliente(cliente);
            else
                return _clienteRepository.UpdateCliente(cliente) ;
        }
    }
}
