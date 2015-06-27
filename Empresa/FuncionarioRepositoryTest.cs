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
     [TestClass]
    public class FuncionarioRepositoryTest
    {
         private FuncionarioContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {
            //Inicializa o banco, apagando e recriando-o
            Database.SetInitializer(new DropCreateDatabaseAlways<FuncionarioContext>());
            //Seta um registro padrão pra ser usado nos testes
            _contextForTest = new FuncionarioContext();

            var funcionario = ObjectMother.GetFuncionario();

            var funcionarioPedro = ObjectMother.GetFuncionario();
            funcionarioPedro.Nome = "Pedro";

            var funcionarioHelder = ObjectMother.GetFuncionario();
            funcionarioHelder.Nome = "Helder";


            var funcionarioRafaela = ObjectMother.GetFuncionario();
            funcionarioRafaela.Nome = "Rafaela";


            var funcionarioHeuler = ObjectMother.GetFuncionario();
            funcionarioHeuler.Nome = "Heuler";


            _contextForTest.Funcionarios.Add(funcionario);

            _contextForTest.Funcionarios.Add(funcionarioPedro);

            _contextForTest.Funcionarios.Add(funcionarioHelder);

            _contextForTest.Funcionarios.Add(funcionarioRafaela);

            _contextForTest.Funcionarios.Add(funcionarioHeuler);



            _contextForTest.SaveChanges();
        }


        [TestMethod]
        public void CreateFuncionarioRepositoryTest()
        {
            //Arrange
            Funcionario b = ObjectMother.GetFuncionario();
            IFuncionarioRepository repository = new FuncionarioRepository();

            //Action
            Funcionario newFuncionario = repository.Save(b);

            //Assert
            Assert.IsTrue(newFuncionario.Id > 0);
            Assert.IsTrue(newFuncionario.Dependentes[0].Id > 0);
        }

        [TestMethod]
        public void RetrieveFuncionarioRepositoryTest()
        {
            //Arrange
            IFuncionarioRepository repository = new FuncionarioRepository();

            //Action
            Funcionario funcionario = repository.Get(1);

            //Assert
            Assert.IsNotNull(funcionario);
            Assert.IsTrue(funcionario.Id > 0);
            Assert.IsFalse(string.IsNullOrEmpty(funcionario.Nome));
            //Assert.IsFalse(DateTime(funcionario.DataAdmissao));
            //Assert.IsFalse(DateTime.IsNullOrEmpty(funcionario.DataNascimento));
            //Assert.IsFalse(double.MinValue(00)(funcionario.Cpf));
            Assert.IsFalse(string.IsNullOrEmpty(funcionario.Funcao));

            //Assert - utilizando o Framework FluentAssertions
            //Apenas um exemplo didático (NÃO CAI NA PROVA)
            //blog.Should().NotBeNull();
            //blog.ShouldBeEquivalentTo(ObjectMother.GetBlog(), options => options.Excluding(b => b.Id));
        }


        [TestMethod]
        public void UpdateFuncionarioRepositoryTest()
        {
            //Arrange
            IFuncionarioRepository repository = new FuncionarioRepository();
            Funcionario funcionario = _contextForTest.Funcionarios.Find(2);
            funcionario.Nome = "Teste";
            funcionario.DataAdmissao = DateTime.Now;
            funcionario.DataNascimento = new DateTime(1995, 06, 01, 0, 0, 0);
            funcionario.Cpf = "902901920192";
            funcionario.Funcao = "Programador";

            //Action
            var updatedFuncionario = repository.Update(funcionario);

            //Assert
            IFuncionarioRepository repository2 = new FuncionarioRepository();
            var persistedFuncionario = _contextForTest.Funcionarios.Find(2);
            Assert.IsNotNull(updatedFuncionario);
            Assert.AreEqual(updatedFuncionario.Id, persistedFuncionario.Id);
            Assert.AreEqual(updatedFuncionario.Nome, persistedFuncionario.Nome);
            Assert.AreEqual(updatedFuncionario.DataAdmissao, persistedFuncionario.DataAdmissao);
            Assert.AreEqual(updatedFuncionario.DataNascimento, persistedFuncionario.DataNascimento);
            Assert.AreEqual(updatedFuncionario.Cpf, persistedFuncionario.Cpf);
            Assert.AreEqual(updatedFuncionario.Funcao, persistedFuncionario.Funcao);

            //Assert - utilizando o Framework FluentAssertions
            //Apenas um exemplo didático (NÃO CAI NA PROVA)
            // updatedBlog.Should().NotBeNull();
            //updatedBlog.ShouldBeEquivalentTo(persistedBlog);
        }

        [TestMethod]
        public void DeleteFuncionarioRepositoryTest()
        {
            //Arrange
            IFuncionarioRepository repository = new FuncionarioRepository();

            //Action
            var deletedFuncionario = repository.Delete(1);

            //Assert
            var contextForTest = new FuncionarioContext();
            var persistedFuncionario = contextForTest.Funcionarios.Find(1);
            Assert.IsNull(persistedFuncionario);
            
           
            //Assert - utilizando o Framework FluentAssertions
            //Apenas um exemplo didático (NÃO CAI NA PROVA)
          //  persistedFuncionario.Should().BeNull();
        }

        [TestMethod]
        public void RetrieveFuncionarioByNameRepositoryTest()
        {
            //Arrange
            IFuncionarioRepository repository = new FuncionarioRepository();

            //Action
            var funcionarios = repository.GetById(1);

            //Assert
            Assert.IsNotNull(funcionarios);
            Assert.IsTrue(funcionarios.Count == 1);
        }

        [TestMethod]
        public void RetrieveAllFuncionariosRepositoryTest()
        {
            IFuncionarioRepository repository = new FuncionarioRepository();

            //Action
            var funcionarios = repository.GetAll();

            //Assert
            Assert.IsNotNull(funcionarios);
            Assert.IsTrue(funcionarios.Count >= 5);
        }






    }


}
