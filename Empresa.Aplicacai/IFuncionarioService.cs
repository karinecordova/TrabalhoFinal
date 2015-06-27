using Empresa.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacai
{
    public interface IFuncionarioService
    {

        Funcionario Create(Funcionario funcionario);
        Funcionario Retrieve(int id);
        Funcionario Update(Funcionario funcionario);
        Funcionario Delete(int id);
        List<Funcionario> RetrieveAll();


    }
}
