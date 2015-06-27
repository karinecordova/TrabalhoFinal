using Empresa.Aplicacai;
using Empresa.Dominio;
using Empresa.Infra.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    [TestClass]
    public class FuncionarioServiceTest
    {
        [TestMethod]
        public void CreateFuncionarioServiceValidationAndPersistenceTest()
        {
            //Arrange
            Funcionario funcionario = ObjectMother.GetFuncionario();
            //Fake do repositório
            var repositoryFake = new Mock<IFuncionarioRepository>();
            repositoryFake.Setup(r => r.Save(funcionario)).Returns(funcionario);
            //Fake do dominio
            var funcionarioFake = new Mock<Funcionario>();
            funcionarioFake.As<IObjectValidation>().Setup(b => b.Validate());

            IFuncionarioService service = new FuncionarioService(repositoryFake.Object);

            //Action
            service.Create(funcionarioFake.Object);

            //Assert
            funcionarioFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Save(funcionarioFake.Object));
        }

        [TestMethod]
        public void RetrieveFuncionarioServiceTest()
        {
            //Arrange
            Funcionario funcionario = ObjectMother.GetFuncionario();
            //Fake do repositório
            var repositoryFake = new Mock<IFuncionarioRepository>();
            repositoryFake.Setup(r => r.Get(1)).Returns(funcionario);

            IFuncionarioService service = new FuncionarioService(repositoryFake.Object);

            //Action
            var funcionarioFake = service.Retrieve(1);

            //Assert
            repositoryFake.Verify(r => r.Get(1));
            Assert.IsNotNull(funcionarioFake);
        }

        [TestMethod]
        public void UpdateFuncionarioServiceValidationAndPersistenceTest()
        {
            //Arrange
            Funcionario funcionario = ObjectMother.GetFuncionario();
            //Fake do repositório
            var repositoryFake = new Mock<IFuncionarioRepository>();
            repositoryFake.Setup(r => r.Update(funcionario)).Returns(funcionario);
            //Fake do dominio
            var funcionarioFake = new Mock<Funcionario>();
            funcionarioFake.As<IObjectValidation>().Setup(b => b.Validate());

            IFuncionarioService service = new FuncionarioService(repositoryFake.Object);

            //Action
            service.Update(funcionarioFake.Object);

            //Assert
            funcionarioFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Update(funcionarioFake.Object));
        }

        [TestMethod]
        public void DeleteFuncionarioServiceTest()
        {
            //Arrange
            Funcionario blog = null;
            //Fake do repositório
            var repositoryFake = new Mock<IFuncionarioRepository>();
            repositoryFake.Setup(r => r.Delete(1)).Returns(blog);

            IFuncionarioService service = new FuncionarioService(repositoryFake.Object);

            //Action
            var funcionarioFake = service.Delete(1);

            //Assert
            repositoryFake.Verify(r => r.Delete(1));
            Assert.IsNull(funcionarioFake);
        }



    }
}
