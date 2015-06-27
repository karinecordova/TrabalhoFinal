using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Empresa.Infra.Data;
using Empresa.Dominio;

namespace Empresa
{
    [TestClass]
    public class FuncionarioDomainTest
    {
        [TestMethod]
        public void CreateAFuncionarioTest()
        {
            Funcionario funcionario = ObjectMother.GetFuncionario();

            Assert.IsNotNull(funcionario);
        }


        [TestMethod]
        public void CreateAValidFuncionarioTest()
        {
            Funcionario funcionario = ObjectMother.GetFuncionario();

            Validator.Validate(funcionario);
        }

       /* [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidFuncionarioNameTest()
        {
            Funcionario funcionario = new Funcionario();

            Validator.Validate(funcionario);
        }*/


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidFuncionarioNameTest()
        {
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "";

            Validator.Validate(funcionario);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidFuncionarioDataNascimentoTest()
        {
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "Karine";
            funcionario.DataNascimento = new DateTime(1990, 06, 01, 0, 0, 0);
           

            Validator.Validate(funcionario);
        }
    }
}
