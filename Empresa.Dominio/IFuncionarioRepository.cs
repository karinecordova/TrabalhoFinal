using Empresa.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa
{
    public interface IFuncionarioRepository
    {
        Funcionario Save(Funcionario funcionario);
        Funcionario Get(int id);
        Funcionario Update(Funcionario funcionario);
        Funcionario Delete(int i);
        List<Funcionario> GetAll();

        List<Funcionario> GetById(int id);
    }
}
