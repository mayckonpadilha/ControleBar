using ControleDeBar.ConsoleApp.ModuloConta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloComanda
{
    public class FaturamentoDiario
    {
        private ArrayList comandasFechadas;

        public FaturamentoDiario(ArrayList contas)
        {
            this.comandasFechadas = contas;
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;

            foreach (Comanda comanda in comandasFechadas)
            {
                total += comanda.CalcularValorTotal();
            }

            return total;
        }
    }
}
