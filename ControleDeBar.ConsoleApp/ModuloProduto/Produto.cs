using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class Produto: EntidadeBase
    {
        public string nome;
        public string preco;


        public Produto(string nome, string preco)
        {
            this.nome = nome;
            this.preco = preco;
           
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Produto produtoAtualizado = (Produto)registroAtualizado;

            this.nome = produtoAtualizado.nome;
            this.preco = produtoAtualizado.preco;
            
        }

        public override ArrayList Validar()
        {
            ArrayList erro = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erro.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(preco.Trim()))
                erro.Add("O campo \"endereço\" é obrigatório");

            

            return erro;
        }


    }
}
