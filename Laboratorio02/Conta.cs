using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio02
{
    class Conta
    {
        private int numIdentificacao;
        private String nomeCorrentista;
        private float saldo;
        private bool contaCorrente;

        public int NumIdentificacao { get => numIdentificacao; }
        public string NomeCorrentista { get => nomeCorrentista; }

        public Conta(int numIdentificacao_, String nomeCorrentista_, bool contaCorrente_)
        {
            this.numIdentificacao = numIdentificacao_;
            this.nomeCorrentista = nomeCorrentista_;
            this.saldo = 0;
            this.contaCorrente = contaCorrente_;
        }

        public void SacarDinheiro(float valorParaSacar)
        {
            float valorComTarifa;

            if (contaCorrente)
            {
                valorComTarifa = valorParaSacar * 1.0037f;
            }
            else
            {
                valorComTarifa = valorParaSacar * 1.002f;
            }

            if ((VerificarSaldo() - valorComTarifa) < 0)
            {
                Console.WriteLine("Erro. Saque da conta de " + this.nomeCorrentista + " no valor de R$ " + valorParaSacar + " é impossível. Saldo insuficiente.");
                Console.WriteLine("Operação cancelada.");
            }
            else
            {
                saldo -= valorComTarifa;
            }
        }

        public void DepositarDinheiro(float valorParaDepositar)
        {
            saldo += valorParaDepositar;
            Console.WriteLine("Depósito na conta de " + this.nomeCorrentista + " no valor de R$ " + valorParaDepositar + " bem sucedido.");
        }

        public void TransferirDinheiro(float valorParaTransferir, int idContaDestino, Conta[] contasRegistradas)
        {
            float valorComTarifa;

            if (contaCorrente)
            {
                valorComTarifa = valorParaTransferir * 1.001f;
            }
            else
            {
                valorComTarifa = valorParaTransferir * 1.0015f;
            }

            if ((VerificarSaldo() - valorComTarifa) < 0)
            {
                Console.WriteLine("Erro. Transferência de R$" + valorParaTransferir + " é impossível. Saldo insuficiente.");
                Console.WriteLine("Operação cancelada.");
                return;
            }
            else
            {
                saldo -= valorComTarifa;
            }

            foreach (Conta contaRegistrada in contasRegistradas)
            {
                if (idContaDestino == contaRegistrada.NumIdentificacao)
                {
                    contaRegistrada.DepositarDinheiro(valorParaTransferir);
                    Console.WriteLine("Transferência de " + this.nomeCorrentista + " para " + contaRegistrada.NomeCorrentista + " no valor de R$ " + valorParaTransferir + " bem sucedida!");
                    break;
                }
            }
        }

        public float VerificarSaldo()
        {
            return this.saldo;
        }
    }
}
