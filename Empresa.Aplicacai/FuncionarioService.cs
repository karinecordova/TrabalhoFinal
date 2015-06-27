using Empresa.Dominio;
using Empresa.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacai
{
    public class FuncionarioService :IFuncionarioService
    {
        private IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public Funcionario Create(Funcionario funcionario)
        {
            Validator.Validate(funcionario);

            var savedFuncionario = _funcionarioRepository.Save(funcionario);

            return savedFuncionario;
        }


        public Funcionario Retrieve(int id)
        {
            return _funcionarioRepository.Get(id);
        }


        public Funcionario Update(Funcionario funcionario)
        {
            Validator.Validate(funcionario);

            var updatedFuncionario = _funcionarioRepository.Update(funcionario);

            return updatedFuncionario;
        }


        public Funcionario Delete(int id)
        {
            return _funcionarioRepository.Delete(id);
        }


        public List<Funcionario> RetrieveAll()
        {
            return _funcionarioRepository.GetAll();
        }



    }
}
