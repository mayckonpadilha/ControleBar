using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloPedido;
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
        public Produto produto;
        public int quantidade;
        public DateTime data;
        public Funcionario funcionario;
        public Mesa mesa;

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override ArrayList Validar()
        {
            throw new NotImplementedException();
        }
    }
}
