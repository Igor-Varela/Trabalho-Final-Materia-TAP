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
    public class FuncionarioService : IFuncionarioService
    {

        private readonly SqlConfiguration _configuration;
        private IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _funcionarioRepository = new FuncionarioRepository(configuration.ConnectionString);
        }

        public Task<bool> DeleteFuncionario(int id)
        {
            return _funcionarioRepository.DeleteFuncionario(id);
        }

        public Task<IEnumerable<Funcionario>> GetAllFuncionarios()
        {
            return _funcionarioRepository.GetAllFuncionarios();
        }

        public Task<Funcionario> GetDetails(int id)
        {
            return _funcionarioRepository.GetFuncionarioDetails(id);
        }

        public Task<bool> SaveFuncionario(Funcionario funcionario)
        {
            if (funcionario.Id == 0)
                return _funcionarioRepository.InsertFuncionario(funcionario);
            else
                return _funcionarioRepository.UpdateFuncionario(funcionario);
        }
    }
}
