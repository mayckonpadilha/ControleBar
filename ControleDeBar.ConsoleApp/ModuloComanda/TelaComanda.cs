using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloGarcom;
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
    internal class TelaComanda : TelaBase
    {
        private RepositorioComanda repositorioComanda;

        private RepositorioMesa repositorioMesa;
        private TelaMesa telaMesa;

        private RepositorioFuncionario repositorioFuncionario;
        private TelaFuncionario telaFuncionario;

        private RepositorioProduto repositorioProduto;
        private TelaProduto telaProduto;

        public TelaComanda(RepositorioComanda repositorioComanda,RepositorioMesa repositorioMesa, TelaMesa telaMesa,RepositorioFuncionario repositorioFuncionario, TelaFuncionario telaFuncionario,RepositorioProduto repositorioProduto, TelaProduto telaProduto)
        {
            this.repositorioBase = repositorioComanda;
            this.repositorioMesa = repositorioMesa;
            this.telaMesa = telaMesa;
            this.repositorioFuncionario = repositorioFuncionario;
            this.telaFuncionario = telaFuncionario;
            this.repositorioProduto = repositorioProduto;
            this.telaProduto = telaProduto;

            nomeEntidade = "Pedido";
        }

        public override void InserirNovoRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Inserindo um novo registro...");

            bool temFuncionarios = repositorioFuncionario.TemRegistros();

            if (temFuncionarios == false)
            {
                MostrarMensagem("Cadastre ao menos um funcionário para cadastrar seu pedido", ConsoleColor.DarkYellow);
                return;
            }

            bool temProduto = repositorioProduto.TemRegistros();

            if (temProduto == false)
            {
                MostrarMensagem("Cadastre ao menos um Produto para solicitar um pedido", ConsoleColor.DarkYellow);
                return;
            }

            bool temMesa = repositorioMesa.TemRegistros();

            if (temMesa == false)
            {
                MostrarMensagem("Cadastre ao menos um paciente para cadastrar requisições de saída", ConsoleColor.DarkYellow);
                return;
            }

            Comanda registro = (Comanda)ObterRegistro();

            if (TemErrosDeValidacao(registro))
            {
                return;
            }

            registro.Comanda();

            repositorioBase.Inserir(registro);

            MostrarMensagem("Registro inserido com sucesso!", ConsoleColor.Green);
        }

        public override void EditarRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Editando um registro já cadastrado...");

            bool temFuncionarios = repositorioFuncionario.TemRegistros();

            if (temFuncionarios == false)
            {
                MostrarMensagem("Cadastre ao menos um funcionário para solicitar pedido", ConsoleColor.DarkYellow);
                return;
            }

            bool temProduto = repositorioProduto.TemRegistros();

            if (temProduto == false)
            {
                MostrarMensagem("Cadastre ao menos um produto para solicitar um pedido", ConsoleColor.DarkYellow);
                return;
            }

            bool temMesa = repositorioMesa.TemRegistros();

            if (temMesa == false)
            {
                MostrarMensagem("Cadastre ao menos uma mesa para solicitar um pedido", ConsoleColor.DarkYellow);
                return;
            }

            VisualizarRegistros(false);

            Console.WriteLine();

            Comanda solicitarPedido = (Comanda)EncontrarRegistro("Digite o id do pedido: ");

            Comanda requisicaoSaidaAtualizado = (Comanda)ObterRegistro();

            if (TemErrosDeValidacao(requisicaoSaidaAtualizado))
            {
                return;
            }

            solicitarPedido.DesfazerRegistroSaida();

            requisicaoSaidaAtualizado.RegistrarSaida();

            repositorioBase.Editar(requisicaoSaida, requisicaoSaidaAtualizado);

            MostrarMensagem("Registro editado com sucesso!", ConsoleColor.Green);
        }

        public override void ExcluirRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Excluindo um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            //int id = EncontrarId();

            RequisicaoSaida requisicaoSaida = (RequisicaoSaida)EncontrarRegistro("Digite o id do registro: ");

            requisicaoSaida.DesfazerRegistroSaida();

            repositorioBase.Excluir(requisicaoSaida);

            MostrarMensagem("Registro excluído com sucesso!", ConsoleColor.Green);
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            const string FORMATO_TABELA = "{0, -10} | {1, -10} | {2, -20} | {3, -20} | {4, -20} | {5, -20}";

            Console.WriteLine(FORMATO_TABELA, "Id", "Data", "Medicamento", "Fonecedor", "Paciente", "Quantidade");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (RequisicaoSaida requisicaoSaida in registros)
            {
                Console.WriteLine(FORMATO_TABELA,
                    requisicaoSaida.id,
                    requisicaoSaida.data.ToShortDateString(),
                    requisicaoSaida.medicamento.nome,
                    requisicaoSaida.medicamento.fornecedor.nome,
                    requisicaoSaida.paciente.nome,
                    requisicaoSaida.quantidade);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Medicamento medicamento = ObterMedicamento();

            Funcionario funcionario = ObterFuncionario();

            Paciente paciente = ObterPaciente();

            Console.Write("Digite a quantidade de caixas: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a data: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            return new RequisicaoSaida(medicamento, quantidade, data, funcionario, paciente);
        }

        private Paciente ObterPaciente()
        {
            telaPaciente.VisualizarRegistros(false);

            Paciente paciente = (Paciente)telaPaciente.EncontrarRegistro("Digite o id do paciente: ");

            Console.WriteLine();

            return paciente;
        }

        private Funcionario ObterFuncionario()
        {
            telaFuncionario.VisualizarRegistros(false);

            Funcionario funcionario = (Funcionario)telaFuncionario.EncontrarRegistro("Digite o id do funcionário: ");

            Console.WriteLine();

            return funcionario;
        }

        private Medicamento ObterMedicamento()
        {
            telaMedicamento.VisualizarRegistros(false);

            Medicamento medicamento = (Medicamento)telaMedicamento.EncontrarRegistro("Digite o id do medicamento: ");

            Console.WriteLine();

            return medicamento;
        }
    }
