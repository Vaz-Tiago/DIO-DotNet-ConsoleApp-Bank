using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterAcaoUsuario();

            while(opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        CriarConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterAcaoUsuario();
            }

            Console.WriteLine();
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void ListarContas()
        {
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                Console.WriteLine();
                return;
            }

            foreach (var conta in listaContas)
            {
                Console.WriteLine(conta.ToString());
            }
        }

        private static void CriarConta()
        {
            Console.Clear();
            Console.WriteLine("INSERIR NOVA CONTA");
            Console.WriteLine("------------------");
            Console.WriteLine();

            Console.Write("Digite 1 para Conta Física ou 2 para Conta Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            var numeroConta = listaContas.Count + 1;

            Conta novaConta = new Conta(
                numero: numeroConta,
                tipoConta: (TipoConta)entradaTipoConta,
                saldo: entradaSaldo,
                credito: entradaCredito,
                nome: entradaNome
            );

            listaContas.Add(novaConta);
        }

        private static void Sacar()
        {
            Console.Clear();
            Console.WriteLine("REALIZAR SAQUE");
            Console.WriteLine();

            Console.Write("Numero da conta: ");
            int entradaConta = int.Parse(Console.ReadLine());
            try 
            {
                var conta = listaContas.Find(c => c.Numero == entradaConta);
                Console.Write("Valor do Saque: R$ ");
                double entradaSaque = double.Parse(Console.ReadLine());

                conta.Sacar(entradaSaque);
            }
            catch
            {
                Console.WriteLine("Conta não encontrada");
                return;
            }
        }

        private static void Depositar()
        {
            Console.Clear();
            Console.WriteLine("REALIZAR DEPOSITO");
            Console.WriteLine();

            Console.Write("Numero da conta: ");
            int entradaConta = int.Parse(Console.ReadLine());
            try 
            {
                var conta = listaContas.Find(c => c.Numero == entradaConta);
                Console.Write("Valor do Deposito: R$ ");
                double entradaDeposito = double.Parse(Console.ReadLine());

                conta.Depositar(entradaDeposito);
            }
            catch
            {
                Console.WriteLine("Conta não encontrada");
                return;
            }
        }

        private static void Transferir()
        {
            Console.Clear();
            Console.WriteLine("REALIZAR TRANSFERENCIA");
            Console.WriteLine();

            Console.Write("Numero da sua conta: ");
            int entradaConta = int.Parse(Console.ReadLine());
            try 
            {
                var conta = listaContas.Find(c => c.Numero == entradaConta);

                Console.Write("Número da conta destino: ");
                int entradaContaDestino = int.Parse(Console.ReadLine());

                var contaDestino = listaContas.Find(c => c.Numero == entradaContaDestino);
                
                Console.Write("Valor da transferencia: R$ ");
                double entradaTransferencia = double.Parse(Console.ReadLine());

                conta.Transferir(entradaTransferencia, contaDestino);
            }
            catch
            {
                Console.WriteLine("Conta não encontrada");
                return;
            }
        }
        private static string ObterAcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO BANK AO SEU DISPOR!!!");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        
    }
}
