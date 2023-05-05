using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class TelaMesa :TelaBase
    {
        public TelaMesa(RepositorioMesa repositorioMesa)
        {
            this.repositorioBase = repositorioMesa;
            nomeEntidade = "Mesa";
            sufixo = "s";
        }

        protected override void MostrarTabela(ArrayList registros)

        {
            
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Numero", "Ocupada");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Mesa mesa in registros)
            {
                string ocupada = mesa.ocupada ? "Ocupada" : "Desocupada";
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", (mesa.id, mesa.numero, ocupada);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite o numero da mesa: ");
            string numeroMesa = Console.ReadLine();



            return new Mesa(numeroMesa);
        }
    }
}
