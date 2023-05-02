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

            Console.WriteLine("Digite 1 para Cadastrar Mesa");
            Console.WriteLine("Digite 2 para Cadastrar Funcionários");
            Console.WriteLine("Digite 3 para Cadastrar Produto");
            Console.WriteLine("Digite 4 para Cadastrar uma Comanda");




            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}

