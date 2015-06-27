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
    public class DependenteRepository : IDependenteRepository
    {
        private FuncionarioContext context;

        public DependenteRepository()
        {
            context = new FuncionarioContext();
        }

        public Dependente Save(Dependente post)
        {
            var newDependente = context.Dependentes.Add(post);
            context.SaveChanges();
            return newDependente;
        }


        public Dependente Get(int id)
        {
            var dependete = context.Dependentes.Find(id);
            return dependete;
        }


        public Dependente Update(Dependente dependente)
        {
            DbEntityEntry entry = context.Entry(dependente);
            entry.State = EntityState.Modified;
            context.SaveChanges();
            return dependente;
        }


        public Dependente Delete(int id)
        {
            var post = context.Dependentes.Find(id);
            DbEntityEntry entry = context.Entry(post);
            entry.State = EntityState.Deleted;
            context.SaveChanges();
            return post;
        }

        public List<Dependente> GetAll()
        {
            return context.Dependentes.ToList();
        }

    }
    
}
