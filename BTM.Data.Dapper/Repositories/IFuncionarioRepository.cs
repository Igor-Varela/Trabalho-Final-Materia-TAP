using BTM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTM.Data.Dapper.Repositories
{
   public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> GetAllFuncionarios();
        Task<Funcionario> GetFuncionarioDetails(int id);
        Task<bool> InsertFuncionario(Funcionario funcionario);
        Task<bool> UpdateFuncionario(Funcionario funcionario);
        Task<bool> DeleteFuncionario(int id);
    }
}
