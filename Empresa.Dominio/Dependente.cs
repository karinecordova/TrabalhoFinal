using Empresa.Infra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Empresa.Dominio
{
    public class Dependente : IObjectValidation
    {

        public int Id { set; get; }

        [DisplayName("Nome Dependente")]
        public string Nome { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Cpf")]
        public String Cpf { get; set; }

        // public int FuncionarioId { set; get; }

        [DisplayName("Funcionario")]
        public virtual Funcionario Funcionario { set; get; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new Exception("Nome Inválido");
            if (DateTime.Now < DataNascimento)
                throw new Exception("Data de nascimento Inválida");
            
            if(DataNascimento.Subtract(DateTime.Today).TotalDays > 6570)
                throw new Exception("Data de nascimento Inválida, o dependente não pode ser maior de 18");
        
                  if (string.IsNullOrEmpty(Cpf))
	            {
		        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
		        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
		        string tempCpf;
		        string digito;
		        int soma;
		        int resto;
		        Cpf = Cpf.Trim();
		        Cpf = Cpf.Replace(".", "").Replace("-", "");
		        if (Cpf.Length != 11)
		          throw new Exception("O Cpf deve ter 11 números - Cpf inválido");
		        tempCpf = Cpf.Substring(0, 9);
		        soma = 0;

		        for(int i=0; i<9; i++)
		            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
		        resto = soma % 11;
		        if ( resto < 2 )
		            resto = 0;
		        else
		           resto = 11 - resto;
		        digito = resto.ToString();
		        tempCpf = tempCpf + digito;
		        soma = 0;
		        for(int i=0; i<10; i++)
		            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
		        resto = soma % 11;
		        if (resto < 2)
		           resto = 0;
		        else
		           resto = 11 - resto;
		        digito = digito + resto.ToString();
		        //return Cpf.EndsWith(digito); Cpf Válido
                throw new Exception("Cpf inválido");
                  
                  }
	
       
        
      
        
        }
    }
}