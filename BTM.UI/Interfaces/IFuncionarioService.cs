using BTM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTM.UI.Interfaces
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<Funcionario>> GetAllFuncionarios();
        Task<Funcionario> GetDetails(int id);
        Task<bool> DeleteFuncionario(int id);
        Task<bool> SaveFuncionario(Funcionario funcionario);
    }
}
