using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using ByteBankImportacaoExportacao.Modelos;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void CriarArquivo()
        {
            using (var fluxoDeArquivo = new FileStream("contas2.csv", FileMode.Create))
            {
                var conta = new ContaCorrente(480, 45984);
                conta.Depositar(450.90);

                var cliente = new Cliente();
                cliente.Nome = "Gustavo";

                conta.Titular = cliente;

                var contaComoString = ConverterContaCorrenteParaString(conta);

                var encoding = Encoding.UTF8;
                var bytes = encoding.GetBytes(contaComoString);


                fluxoDeArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static string ConverterContaCorrenteParaString(ContaCorrente conta)
        {
            var saldo = conta.Saldo.ToString().Replace(',', '.');

            return $"{conta.Agencia},{conta.Numero},{saldo},{conta.Titular.Nome}";
        }


    }
}
