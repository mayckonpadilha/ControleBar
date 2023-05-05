using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp
{
    internal class TelaPrincipal

    {
        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Controle do Bar da Galera\n");

            Console.WriteLine("Digite 1 para Acessar Mesa");
            Console.WriteLine("Digite 2 para Acessar Funcionários");
            Console.WriteLine("Digite 3 para Acessar Produto");
            Console.WriteLine("Digite 4 para Acessar Comanda");




            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}

