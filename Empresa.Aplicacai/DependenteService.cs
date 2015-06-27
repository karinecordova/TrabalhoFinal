using Empresa.Dominio;
using Empresa.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacai
{
    public class DependenteService:IDependenteService
    {

        private IDependenteRepository _dependenteRepository;

        public DependenteService(IDependenteRepository dependenteRepository)
        {
            _dependenteRepository = dependenteRepository;
        }

        public Dependente Create(Dependente dependente)
        {
            Validator.Validate(dependente);

            var savedDependente = _dependenteRepository.Save(dependente);

            return savedDependente;
        }


        public Dependente Retrieve(int id)
        {
            return _dependenteRepository.Get(id);
        }


        public Dependente Update(Dependente dependente)
        {
            Validator.Validate(dependente);

            var updatedDependente = _dependenteRepository.Update(dependente);

            return updatedDependente;
        }


        public Dependente Delete(int id)
        {
            return _dependenteRepository.Delete(id);
        }


        public List<Dependente> RetrieveAll()
        {
            return _dependenteRepository.GetAll();
        }

    }
}
