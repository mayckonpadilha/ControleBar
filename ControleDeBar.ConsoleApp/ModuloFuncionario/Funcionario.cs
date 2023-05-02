using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class Funcionario: EntidadeBase
    {
        public string nome;
        public string endereco;
        public string idade;

        public Funcionario(string nome, string endereco, string idade)
        {
            this.nome = nome;
            this.endereco = endereco;
            this.idade = idade;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Funcionario funcionarioAtualizado = (Funcionario)registroAtualizado;

            this.nome = funcionarioAtualizado.nome;
            this.endereco = funcionarioAtualizado.endereco;
            this.idade = funcionarioAtualizado.idade;
        }

        public override ArrayList Validar()
        {
            ArrayList erro = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erro.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(endereco.Trim()))
                erro.Add("O campo \"endereço\" é obrigatório");

            if (string.IsNullOrEmpty(idade.Trim()))
                erro.Add("O campo \"idade\" é obrigatório");
            
            return erro;
        }
    }
}
