using Empresa.Dominio;
using Empresa.Infra.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    [TestClass]
    public class DependenteDomainTest
    {
        [TestMethod]
        public void CreateADependenteTest()
        {
            Dependente dependente = ObjectMother.GetDependente();

            Assert.IsNotNull(dependente);
        }

        [TestMethod]
        public void CreateAValidDependenteTest()
        {
            
            Dependente dependente = ObjectMother.GetDependente();

            Validator.Validate(dependente);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidDependenteNameTest()
        {
            Dependente dependente = new Dependente();

            Validator.Validate(dependente);
        }

        [TestMethod]
       [ExpectedException(typeof(Exception))]
        public void CreateAInvalidDependenteContentTest()
        {
            
            Dependente dependente = new Dependente();
            dependente.Nome = "";
          
            
            Validator.Validate(dependente);
        }

        [TestMethod]
        //[ExpectedException(typeof(Exception))]
        public void CreateAInvalidDependenteDateTest()
        {
            Dependente dependente = new Dependente();
            dependente.Nome = "João";
            dependente.Cpf = "09110956798";
            dependente.DataNascimento = new DateTime(1996, 06, 10, 0, 0, 0);

            Validator.Validate(dependente);
        }
    }

}
