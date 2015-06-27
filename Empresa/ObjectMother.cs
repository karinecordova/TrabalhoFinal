using Empresa.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    public class ObjectMother
    {
        public static Funcionario GetFuncionario()
        {
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "Karine";
            funcionario.DataAdmissao = DateTime.Now;
            funcionario.DataNascimento = new DateTime(1995, 06, 01, 0, 0, 0);
            funcionario.Cpf = "09110956788";
            funcionario.Funcao = "Tester";
            funcionario.Dependentes = new List<Dependente>()
            {
                new Dependente()
                {
                    Nome = "João",
                    DataNascimento = new DateTime(1970, 06, 01, 0, 0, 0),
                    Cpf = "09110956798",
                   
                }
            };

            return funcionario;
        }


        public static Dependente GetDependente()
        {

            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "Karine";
            funcionario.DataAdmissao = DateTime.Now;
            funcionario.DataNascimento = new DateTime(1995, 06, 01, 0, 0, 0);
            funcionario.Cpf = "0911095678";
            funcionario.Funcao = "Tester";

            Dependente dependente = new Dependente();
            dependente.Nome = "João";
            dependente.DataNascimento = DateTime.Now;
            dependente.Cpf = "0911095679";
            dependente.Funcionario = funcionario;

            return dependente;
        }

        public static List<Dependente> GetDependentes()
        {
            List<Dependente> dependentes = new List<Dependente>();

            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "Karine 2";
            funcionario.DataAdmissao = DateTime.Now;
            funcionario.DataNascimento = new DateTime(1990, 06, 01, 0, 0, 0);
            funcionario.Cpf = "091156568";
            funcionario.Funcao = "Suporte";

            Dependente dependente = new Dependente();
            dependente.Nome = "João 2";
            dependente.DataNascimento = new DateTime(1990, 06, 01, 0, 0, 0);
            dependente.Cpf = "0911455679";
            dependente.Funcionario = funcionario;

            Dependente dependente2 = new Dependente();
            dependente2.Nome = "João 3";
            dependente2.DataNascimento = new DateTime(1990, 06, 01, 0, 0, 0);
            dependente2.Cpf = "0911455679";
            dependente2.Funcionario = funcionario;

            Dependente dependente3 = new Dependente();
            dependente3.Nome = "João 4";
            dependente3.DataNascimento = new DateTime(1990, 06, 01, 0, 0, 0);
            dependente3.Cpf = "0911455679";
            dependente3.Funcionario = funcionario;

            Dependente dependente4 = new Dependente();
            dependente4.Nome = "João 4";
            dependente4.DataNascimento = new DateTime(1990, 06, 01, 0, 0, 0);
            dependente4.Cpf = "0911455679";
            dependente4.Funcionario = funcionario;

            dependentes.Add(dependente);
            dependentes.Add(dependente2);
            dependentes.Add(dependente3);
            dependentes.Add(dependente4);

            return dependentes;
        }






    }
}
