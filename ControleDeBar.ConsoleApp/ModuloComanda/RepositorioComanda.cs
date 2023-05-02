using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
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
    public class RepositorioComanda: RepositorioBase
    {
        public RepositorioComanda(ArrayList listaRequisicaoSaida)
        {
            this.listaRegistros = listaRequisicaoSaida;
        }

        public override Comanda SelecionarPorId(int id)
        {
            return (Comanda)base.SelecionarPorId(id);
        }
    }
    ]