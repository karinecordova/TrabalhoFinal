using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Dominio
{
    public interface IDependenteRepository
    {

        Dependente Save(Dependente dependente);
        Dependente Get(int id);
        Dependente Update(Dependente dependente);
        Dependente Delete(int i);

        List<Dependente> GetAll();

    }
}
