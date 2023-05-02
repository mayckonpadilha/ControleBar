using ControleDeBar.ConsoleApp.ModuloComanda;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System.Collections;

namespace ControleDeBar.ConsoleApp
{
    internal class Program
    {


        static void Main(string[] args)
        {
            RepositorioMesa repositorioMesa = new RepositorioMesa(new ArrayList());
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario(new ArrayList());
            RepositorioProduto repositorioProduto = new RepositorioProduto(new ArrayList());
            RepositorioComanda repositorioComanda = new RepositorioComanda(new ArrayList());
            TelaMesa telaMesa = new TelaMesa(repositorioMesa);
            TelaFuncionario telaFuncionario = new TelaFuncionario(repositorioFuncionario);
            TelaProduto telaPoduto = new TelaProduto(repositorioProduto);
            TelaComanda telaComanda = new TelaComanda(repositorioComanda);

            TelaPrincipal principal = new TelaPrincipal();


            while (true)
            {
                string opcao = principal.ApresentarMenu();

                if (opcao == "s")
                    break;

                if (opcao == "1")
                {
                    string subMenu = telaMesa.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaMesa.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaMesa.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaMesa.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaMesa.ExcluirRegistro();
                    }
                }
                else if (opcao == "2")
                {
                    string subMenu = telaFuncionario.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaFuncionario.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaFuncionario.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaFuncionario.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaFuncionario.ExcluirRegistro();
                    }
                }
                else if (opcao == "3")
                {
                    string subMenu = telaPoduto.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaPoduto.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaPoduto.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaPoduto.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaPoduto.ExcluirRegistro();
                    }
                }
                else if (opcao == "4")
                {
                    string subMenu = telaPoduto.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaComanda.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaComanda.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaComanda.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaComanda.ExcluirRegistro();
                    }
                }

            }
        }
    }
}




