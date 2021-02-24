using System;

namespace DIO.Bank
{
    public class Conta
    {
        public int Numero { get; private set; }
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        public string Nome { get; private set; }

        public Conta(int numero, TipoConta tipoConta, double saldo, double credito, string nome) 
        {
            this.Numero = numero;
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }


        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine($"Olá {this.Nome}, seu saldo atual: {this.Saldo}");
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine($"Olá {this.Nome} seu saldo é ${this.Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
                contaDestino.Depositar(valorTransferencia);
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += $"Conta: {this.Numero} | ";
            retorno += $"Tipo da Conta: {this.TipoConta} | ";
            retorno += $"Nome: {this.Nome} | ";
            retorno += $"Saldo: {this.Saldo} | ";
            retorno += $"Crédito: {this.Credito}";
            return retorno;
        }

        public Conta()
        {
            
        }

    }
}