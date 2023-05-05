using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloComanda;
using ControleDeBar.ConsoleApp.ModuloFuncionario;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    internal class Comanda : EntidadeBase
    {



        public Mesa mesa;
        public ArrayList pedidos;
        public Funcionario funcionario;
        public bool estaAberta;
        public DateTime data;


        public Comanda(Mesa m, Funcionario f, DateTime dataAbertura)
        {
            mesa = m;
            funcionario = f;
            pedidos = new ArrayList();
            data = dataAbertura;

            AbrirComanda();
        }

        public void RegistrarPedido(Produto produto, int quantidadeAdicionado)
        {
            Pedido pedidoNovo = new Pedido(produto, quantidadeAdicionado);
            pedidos.Add(pedidoNovo);
        }
        public decimal CalcularValorTotal()
        {
            decimal total = 0;

            foreach (Pedido pedido in pedidos)
            {
                decimal totalPedido = pedido.CalcularValorParc();

                total += totalPedido;
            }

            return total;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Comanda comandaAtualizada = (Comanda)registroAtualizado;

            funcionario = comandaAtualizada.funcionario;
            mesa = comandaAtualizada.mesa;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (funcionario == null)
            {
                erros.Add("O campo \"Funcionario\" é obrigatorio");
            }

            if (mesa == null)
            {
                erros.Add("O campo \"Mesa\" é obrigatorio");
            }

            return erros;
        }

        private void AbrirComanda()
        {
            estaAberta = true;
            mesa.Ocupar();
        }

        public void FecharComanda()
        {
            estaAberta = false;
            mesa.Desocupar();
        }

} 
}
