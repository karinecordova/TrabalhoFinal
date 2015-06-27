using Empresa.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Infra.Data
{
    public class FuncionarioRepository: IFuncionarioRepository
    {
        private FuncionarioContext context;

        public FuncionarioRepository()
        {
            context = new FuncionarioContext();
        }

        public Funcionario Save(Funcionario funcionario)
        {
            var newFuncionario = context.Funcionarios.Add(funcionario);
            context.SaveChanges();
            return newFuncionario;
        }


        public Funcionario Get(int id)
        {
            var funcionario = context.Funcionarios.Find(id);
            return funcionario;
        }


        public Funcionario Update(Funcionario funcionario)
        {
            DbEntityEntry entry = context.Entry(funcionario);
            entry.State = EntityState.Modified;
            context.SaveChanges();
            return funcionario; 
        }


        public Funcionario Delete(int id)
        {
            var funcionario = context.Funcionarios.Find(id);
            DbEntityEntry entry = context.Entry(funcionario);
            entry.State = EntityState.Deleted;
            context.SaveChanges();
            return funcionario;
        }


        public List<Funcionario> GetAll()
        {
            return context.Funcionarios.ToList();
        }


        public List<Funcionario> GetById(int id)
        {
            return context.Funcionarios.Where(funcionario => funcionario.Id == id).ToList();
        }
    


    }
}
