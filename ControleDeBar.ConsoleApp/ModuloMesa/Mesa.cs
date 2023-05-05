using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class Mesa:EntidadeBase
    {
        public string numero;
        public bool ocupada;

        public Mesa(string numeroMesa)
        {
            numero = numeroMesa;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizada = (Mesa)registroAtualizado;

            this.numero = mesaAtualizada.numero;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(numero.Trim()))
            {
                erros.Add("O campo \"Número da Mesa\" é obrigatorio");
            }
            return erros;



        }
        public void Desocupar()
        {
            ocupada = false; ;
        }

        public void Ocupar()
        {
            ocupada = true;
        }


    }
}
