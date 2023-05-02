using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
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
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}| {3, -20}| {4, -20}| {5, -20}", "Id", "Numero", "Localização","Quantidade de Lugares", "Ocupada");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Mesa mesa in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}| {3, -20}| {4, -20}| {5, -20}", mesa.id, mesa.numero,mesa.localizacao, mesa.quantidadeLugares, mesa.ocupado);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string numero = Console.ReadLine();

            Console.Write("Digite o Endereço: ");
            string localizacao = Console.ReadLine();

            Console.Write("Digite o Endereço: ");
            string quantidadeLugares = Console.ReadLine();

            bool ocupado = false;



            return new Mesa(numero, localizacao, quantidadeLugares,ocupado);
        }
    }
}
