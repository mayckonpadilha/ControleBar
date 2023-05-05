using ControleDeBar.ConsoleApp.Compartilhado;
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
        public decimal preco;


        public Produto(string nome, decimal preco)
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

            if (preco == 0)
            {
                erro.Add("O campo \"Preço\" é obrigatorio");
            }



            return erro;
        }


    }
}
