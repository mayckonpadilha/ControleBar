using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
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
        public string localizacao;
        public string quantidadeLugares;
        public bool ocupado;

        public Mesa(string numero, string localizacao, string quantidadeLugares, bool ocupado)
        {
            this.numero = numero;
            this.localizacao = localizacao;
            this.quantidadeLugares = quantidadeLugares;
            this.ocupado = ocupado;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizado = (Mesa)registroAtualizado;

            this.numero = mesaAtualizado.numero;
            this.localizacao = mesaAtualizado.localizacao;
            this.quantidadeLugares = mesaAtualizado .quantidadeLugares;
            this.ocupado = mesaAtualizado.ocupado;
        }

        public override ArrayList Validar()
        {
            ArrayList erro = new ArrayList();

            if (string.IsNullOrEmpty(numero.Trim()))
                erro.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(localizacao.Trim()))
                erro.Add("O campo \"Localização\" é obrigatório");

            if (string.IsNullOrEmpty(quantidadeLugares.Trim()))
                erro.Add("O campo \"Quantidade de Lugares\" é obrigatório");



            return erro;
        }

       
    }
}
