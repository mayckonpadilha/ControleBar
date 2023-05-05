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
    public class RepositorioComanda : RepositorioBase
    {
        public RepositorioComanda(ArrayList listaComandas)
        {
            listaRegistros = listaComandas;
        }

        public ArrayList SelecionarComandasEmAberto()
        {
            ArrayList comandasAberta = new ArrayList();

            foreach (Comanda comanda in listaRegistros)
            {
                if (comanda.estaAberta)
                    comandasAberta.Add(comanda);
            }

            return comandasAberta;
        }

        public ArrayList SelecionarComandasFechadas(DateTime data)
        {
            ArrayList comandasAberta = new ArrayList();

            foreach (Comanda comanda in listaRegistros)
            {
                if (comanda.estaAberta == false && comanda.data.Date == data.Date)
                    comandasAberta.Add(comanda);
            }

            return comandasAberta;
        }
    }
}