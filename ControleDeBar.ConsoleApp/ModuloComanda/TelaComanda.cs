using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloFuncionario;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloComanda
{
    internal class TelaComanda: TelaBase
    {
        private RepositorioComanda repositorioComanda;
        private TelaMesa telaMesa;
        private TelaFuncionario telaFuncionario;
        private TelaProduto telaProduto;
        public TelaComanda(RepositorioComanda repositorioComanda, TelaMesa telaMesa, TelaFuncionario telaFuncionario, TelaProduto telaProduto)
        {
            this.repositorioBase = repositorioComanda;
            this.repositorioComanda = repositorioComanda;
            this.telaMesa = telaMesa;
            this.telaFuncionario = telaFuncionario;
            this.telaProduto = telaProduto;

            nomeEntidade = "Comanda";
            sufixo = "s";
        }

        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Contas \n");

            Console.WriteLine("Digite 1 para Abrir Nova Conta");
            Console.WriteLine("Digite 2 para Registrar Pedidos");
            Console.WriteLine("Digite 3 para Fechar Conta");
            Console.WriteLine("Digite 4 para Visualizar Contas Abertas");

            Console.WriteLine("Digite 5 para Visualizar Faturamento do Dia");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void AbrirNovaComanda()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Inserindo um novo registro...");

            Comanda comanda = (Comanda)ObterRegistro();

            if (TemErrosDeValidacao(comanda))
            {
                AbrirNovaComanda(); //chamada recursiva

                return;
            }

            repositorioBase.Inserir(comanda);

            AdicionarPedidos(comanda);

            MostrarMensagem("Registro inserido com sucesso!", ConsoleColor.Green);
        }

        public bool VisualizarComandasAbertas()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Visualizando comandas em aberto...");

            ArrayList contasEmAberto = repositorioComanda.SelecionarComandasEmAberto();

            if (contasEmAberto.Count == 0)
            {
                MostrarMensagem("Nenhuma comanda em aberto", ConsoleColor.DarkYellow);
                return false;
            }

            MostrarTabela(contasEmAberto);

            return contasEmAberto.Count > 0;
        }

        public void RegistrarPedidos()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Registrando pedidos...");

            bool temComandaEmAberto = VisualizarComandasAbertas();

            if (temComandaEmAberto == false)
                return;

            Comanda comandaSelecionada = (Comanda)EncontrarRegistro("Digite o id da Conta: ");

            Console.WriteLine("Digite 1 para adicionar pedidos");
            Console.WriteLine("Digite 2 para remover pedidos");

            string opcao = Console.ReadLine();

            if (opcao == "1")
                AdicionarPedidos(comandaSelecionada);

            else if (opcao == "2")
                RemoverPedidos(comandaSelecionada);
        }

        public void FecharConta()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Fechando contas...");

            bool temComandaEmAberto = VisualizarComandasAbertas();

            if (temComandaEmAberto == false)
                return;

            Comanda comandaSelecionada = (Comanda)EncontrarRegistro("Digite o id da Conta: ");

            comandaSelecionada.FecharComanda();

            MostrarMensagem("Comanda fechada com sucesso", ConsoleColor.Green);
        }

        public void VisualizarFaturamentoDoDia()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Visualizando faturamento do dia...");

            Console.WriteLine("Digite a data: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            ArrayList comandasFechadasNoDia = repositorioComanda.SelecionarComandasFechadas(data);

            FaturamentoDiario faturamentoDiario = new FaturamentoDiario(comandasFechadasNoDia);

            decimal totalFaturado = faturamentoDiario.CalcularTotal();

            Console.WriteLine("Contas fechadas na data: " + data.ToShortDateString());

            MostrarTabela(comandasFechadasNoDia);

            Console.WriteLine();

            MostrarMensagem("Total faturado: " + totalFaturado, ConsoleColor.Green);
        }

        

        protected override void MostrarTabela(ArrayList registros)
        {
            foreach (Comanda conta in registros)
            {
                Console.WriteLine("Conta: " + conta.id + ", Mesa: " + conta.mesa.numero + ", Garçom: " + conta.funcionario.nome);
                Console.WriteLine();
                foreach (Pedido pedido in conta.pedidos)
                {
                    Console.WriteLine("\tProduto: " + pedido.produto.nome + ", Qtd: " + pedido.quantidade);
                }

                Console.WriteLine("------------------------------------------------------\n");
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Mesa mesaSelecionada = ObterMesa();

            Funcionario funcionarioSelecionado = ObterFuncionario();

            Console.Write("Digite a data: ");

            DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());

            return new Comanda(mesaSelecionada, funcionarioSelecionado, dataAbertura);
        }


        private void AdicionarPedidos(Comanda comandaSelecionada)
        {
            Console.WriteLine("Selecionar produtos? [s] ou [n]");

            Console.Write(" -> ");

            string opcao = Console.ReadLine();

            while (opcao == "s")
            {
                Produto produto = ObterProduto();

                Console.Write("Digite a quantidade: ");
                int quantidade = Convert.ToInt32(Console.ReadLine());

                comandaSelecionada.RegistrarPedido(produto, quantidade);

                Console.WriteLine("Selecionar mais produtos? [s] ou [n]");

                Console.Write(" -> ");

                opcao = Console.ReadLine();
            }
        }

        private Produto ObterProduto()
        {
            telaProduto.VisualizarRegistros(false);

            Produto produto = (Produto)telaProduto.EncontrarRegistro("Digite o id do Produto: ");

            Console.WriteLine();

            return produto;
        }

        private void RemoverPedidos(Comanda comandaSelecionada)
        {
            int id = 0;

            if (comandaSelecionada.pedidos.Count == 0)
            {
                MostrarMensagem("Nenhum pedido cadastrado para esta comanda", ConsoleColor.DarkYellow);
                return;
            }
        }

        private Funcionario ObterFuncionario()
        {
            telaFuncionario.VisualizarRegistros(false);

            Funcionario funcionarioSelecionado = (Funcionario)telaFuncionario.EncontrarRegistro("Digite o id do Funcionario: ");

            Console.WriteLine();

            return funcionarioSelecionado;
        }

        private Mesa ObterMesa()
        {
            telaMesa.VisualizarRegistros(false);

            Mesa mesaSelecionada = (Mesa)telaMesa.EncontrarRegistro("Digite o id da Mesa: ");

            Console.WriteLine();

            return mesaSelecionada;
        }

    }
}
