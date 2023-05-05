using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;



namespace ControleDeBar.ConsoleApp.ModuloFuncionario
{
    public class Funcionario: EntidadeBase
    {
        public string nome;
        

        public Funcionario(string nomeFuncionario)
        {
            this.nome = nomeFuncionario;
           
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Funcionario funcionarioAtualizado = (Funcionario)registroAtualizado;

            this.nome = funcionarioAtualizado.nome;
                
        }
         

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
            {
                erros.Add("O campo \"Nome\" é obrigatório");
            }

            return erros;
        }
    }
}
