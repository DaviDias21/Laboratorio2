using System;

namespace Laboratorio02
{
    class ClasseTeste
    {
        static void Main(string[] args)
        {
            Conta[] registroContas = new Conta[3];

            registroContas[0] = new Conta(123456, "Bob Nelson", true);
            registroContas[1] = new Conta(717171, "Testolfo Rocha", false);
            registroContas[2] = new Conta(654321, "Lisa Leite", true);

            registroContas[0].DepositarDinheiro(5000f);
            registroContas[2].DepositarDinheiro(2000f);
            registroContas[1].DepositarDinheiro(1500f);
            registroContas[0].TransferirDinheiro(600f, 717171, registroContas);
            registroContas[2].SacarDinheiro(250f);
            registroContas[2].TransferirDinheiro(400f, 717171, registroContas);
            registroContas[1].TransferirDinheiro(1000f, 123456, registroContas);
            registroContas[0].SacarDinheiro(900f);
            registroContas[0].TransferirDinheiro(1500f, 654321, registroContas);
            registroContas[1].TransferirDinheiro(1200f, 654321, registroContas);
            registroContas[0].SacarDinheiro(2000f);
            registroContas[2].DepositarDinheiro(100f);
            registroContas[1].TransferirDinheiro(700f, 123456, registroContas);

            Console.WriteLine();
            Console.WriteLine("RESULTADOS FINAIS:");
            foreach(Conta conta in registroContas)
            {
                Console.WriteLine("Saldo de " + conta.NomeCorrentista + " : R$" + conta.VerificarSaldo());
            }

            Console.ReadLine();

        }
    }
}
