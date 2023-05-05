using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloComanda
{
    public class Pedido
    {
        public Produto produto;
        public int quantidade;
        public int id;
        public static int contar;


        public Pedido(Produto produto,int quantidadeAdicionado)
        {
            contar++;
            id = contar;
            this.produto = produto;
            this.quantidade = quantidadeAdicionado;

        }
        public decimal CalcularValorParc()
        {
            return produto.preco * quantidade;
        }
    }
}
