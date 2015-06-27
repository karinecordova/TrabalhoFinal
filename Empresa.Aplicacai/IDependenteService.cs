using Empresa.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacai
{
    public interface IDependenteService
    {
        Dependente Create(Dependente dependente);
        Dependente Retrieve(int id);
        Dependente Update(Dependente dependente);
        Dependente Delete(int id);
        List<Dependente> RetrieveAll();

    }
}
