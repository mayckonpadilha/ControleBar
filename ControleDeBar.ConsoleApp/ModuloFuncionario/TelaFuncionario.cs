using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    internal class TelaFuncionario:TelaBase
    {
        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioBase = repositorioFuncionario;
            nomeEntidade = "Funcionario";
            sufixo = "s";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}| {3, -20}| {4, -20}", "Id", "Nome", "Endereço","Idade");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Funcionario funcionario in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}| {3, -20}| {4, -20}", funcionario.id, funcionario.nome, funcionario.endereco,funcionario.idade);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o Endereço: ");
            string endececo = Console.ReadLine();

            Console.Write("Digite a idade: ");
            string idade = Console.ReadLine();

            return new Funcionario(nome, endececo, idade);
        }
    }
}

