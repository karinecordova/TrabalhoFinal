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
{ [TestClass]
    public class DependenteServiceTest
    {

    [TestMethod]
    public void CreateDependenteServiceValidationAndPersistenceTest()
    {
        //Arrange
        Dependente dependente = ObjectMother.GetDependente();
        //Fake do repositório
        var repositoryFake = new Mock<IDependenteRepository>();
        repositoryFake.Setup(r => r.Save(dependente)).Returns(dependente);
        //Fake do dominio
        var dependenteFake = new Mock<Dependente>();
        dependenteFake.As<IObjectValidation>().Setup(b => b.Validate());

        IDependenteService service = new DependenteService(repositoryFake.Object);

        //Action
        service.Create(dependenteFake.Object);

        //Assert
        dependenteFake.As<IObjectValidation>().Verify(b => b.Validate());
        repositoryFake.Verify(r => r.Save(dependenteFake.Object));
    }

    [TestMethod]
    public void RetrieveDependenteServiceTest()
    {
        //Arrange
        Dependente dependente = ObjectMother.GetDependente();
        //Fake do repositório
        var repositoryFake = new Mock<IDependenteRepository>();
        repositoryFake.Setup(r => r.Get(1)).Returns(dependente);

        IDependenteService service = new DependenteService(repositoryFake.Object);

        //Action
        var dependenteFake = service.Retrieve(1);

        //Assert
        repositoryFake.Verify(r => r.Get(1));
        Assert.IsNotNull(dependenteFake);
    }


    [TestMethod]
    public void UpdateDependenteServiceValidationAndPersistenceTest()
    {
        //Arrange
        Dependente dependente = ObjectMother.GetDependente();
        //Fake do repositório
        var repositoryFake = new Mock<IDependenteRepository>();
        repositoryFake.Setup(r => r.Update(dependente)).Returns(dependente);
        //Fake do dominio
        var dependenteFake = new Mock<Dependente>();
        dependenteFake.As<IObjectValidation>().Setup(b => b.Validate());

        IDependenteService service = new DependenteService(repositoryFake.Object);

        //Action
        service.Update(dependenteFake.Object);

        //Assert
        dependenteFake.As<IObjectValidation>().Verify(b => b.Validate());
        repositoryFake.Verify(r => r.Update(dependenteFake.Object));
    }

    [TestMethod]
    public void DeleteDependenteServiceTest()
    {
        //Arrange
        Dependente dependente = null;
        //Fake do repositório
        var repositoryFake = new Mock<IDependenteRepository>();
        repositoryFake.Setup(r => r.Delete(1)).Returns(dependente);

        IDependenteService service = new DependenteService(repositoryFake.Object);

        //Action
        var dependenteFake = service.Delete(1);

        //Asserts
        repositoryFake.Verify(r => r.Delete(1));
     
        Assert.IsNull(dependenteFake);
    }











    }
}
