using Empresa.Dominio;
using Empresa.Infra.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    public class DependenteRepositoryTest
    {

        private FuncionarioContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {
            //Inicializa o banco, apagando e recriando-o
            Database.SetInitializer(new DropCreateDatabaseAlways<FuncionarioContext>());
            //Seta um registro padrão pra ser usado nos testes
            _contextForTest = new FuncionarioContext();
            _contextForTest.Dependentes.AddRange(ObjectMother.GetDependentes());
            _contextForTest.SaveChanges();
        }

        [TestMethod]
        public void CreateDependenteRepositoryTest()
        {
            //Arrange
            Dependente p = ObjectMother.GetDependente();
            IDependenteRepository repository = new DependenteRepository();

            //Action
            Dependente newDependente = repository.Save(p);

            //Assert
            Assert.IsTrue(newDependente.Id > 0);
        }

        [TestMethod]
        public void RetrieveDependenteRepositoryTest()
        {
            //Arrange
            IDependenteRepository repository = new DependenteRepository();

            //Action
            Dependente dependente = repository.Get(1);

            //Assert
            Assert.IsNotNull(dependente);
            Assert.IsTrue(dependente.Id > 0);
            Assert.IsFalse(string.IsNullOrEmpty(dependente.Nome));
           // Assert.IsFalse(string.IsNullOrEmpty(dependente.DataNascimento));

            //Assert - utilizando o Framework FluentAssertions
            //Apenas um exemplo didático (NÃO CAI NA PROVA)
            //blog.Should().NotBeNull();
            //blog.ShouldBeEquivalentTo(ObjectMother.GetBlog(), options => options.Excluding(b => b.Id));
        }


        [TestMethod]
        public void UpdateDependenteRepositoryTest()
        {
            //Arrange
            IDependenteRepository repository = new DependenteRepository();
            Funcionario funcionario = _contextForTest.Funcionarios.Find(2);
            funcionario.Nome = "Teste";
            funcionario.DataAdmissao = DateTime.Now;
            funcionario.DataNascimento = new DateTime(1970, 06, 01, 0, 0, 0);
            funcionario.Cpf = "902901920192";
            funcionario.Funcao = "Programador";

            Dependente dependente = _contextForTest.Dependentes.Find(1);
            dependente.Nome = "blabla";
             dependente.DataNascimento = new DateTime(2015, 06, 01, 0, 0, 0);
             dependente.Cpf = "90909090";
                      
            dependente.Funcionario = funcionario;

            //Action
            var updatedDependente = repository.Update(dependente);

            //Assert
            var persistedDependente= _contextForTest.Dependentes.Find(1);
            Assert.IsNotNull(updatedDependente);
            Assert.AreEqual(updatedDependente.Id, persistedDependente.Id);
            Assert.AreEqual(updatedDependente.Nome, persistedDependente.Nome);
            Assert.AreEqual(updatedDependente.DataNascimento, persistedDependente.DataNascimento);
            Assert.AreEqual(updatedDependente.Cpf, persistedDependente.Cpf);
            Assert.AreEqual(updatedDependente.Funcionario, persistedDependente.Funcionario);


            //Assert - utilizando o Framework FluentAssertions
            //Apenas um exemplo didático (NÃO CAI NA PROVA)
            // updatedBlog.Should().NotBeNull();
            //updatedBlog.ShouldBeEquivalentTo(persistedBlog);
        }


        [TestMethod]
        public void DeleteDependenteRepositoryTest()
        {
            //Arrange
            IDependenteRepository repository = new DependenteRepository();

            //Action
            var deletedDependente= repository.Delete(1);

            //Assert
            var persistedDependente = _contextForTest.Dependentes.Find(1);
            Assert.IsNull(persistedDependente);

            //Assert - utilizando o Framework FluentAssertions
            //Apenas um exemplo didático (NÃO CAI NA PROVA)
            //persistedPost.Should().BeNull();
        }


        
    }
}
