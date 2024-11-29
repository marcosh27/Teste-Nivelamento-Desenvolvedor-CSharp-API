using System;
using System.Globalization;

namespace Questao1 {
    class Program {
        static void Main(string[] args) {

            ContaBancaria conta;
            bool menu = true;
            Console.Write("Entre o número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            Console.Write("Entre o titular da conta: ");
            string titular = Console.ReadLine();
            Console.Write("Entre com uma senha para a conta: ");
            string senha = Console.ReadLine();
            Console.Write("Haverá depósito inicial (s/n)? ");
            char resp = char.Parse(Console.ReadLine());
            if (resp == 's' || resp == 'S') {
                Console.Write("Entre o valor de depósito inicial: ");
                double depositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta = new ContaBancaria(numero, titular, senha,depositoInicial);
            }
            else {
                conta = new ContaBancaria(numero, titular, senha);
            }
            conta.ConsultarDados();
            while (menu)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Realizar depósito");
                Console.WriteLine("3. Realizar saque");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");
                
                int options = int.Parse(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        conta.ConsultarDados();
                        break;
                    case 2:
                        Console.WriteLine("\nDigite o valor que deseja depositar:");
                        double deposito;
                        if (double.TryParse(Console.ReadLine(), out deposito))
                        {
                            conta.Depositar(deposito);
                            conta.ConsultarDados();
                        }
                        else
                        {
                            Console.WriteLine("Valor de depósito inválido.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nDigite o valor que deseja sacar:");
                        double saque;
                        if (double.TryParse(Console.ReadLine(), out saque))
                        {
                            conta.Sacar(saque);
                            conta.ConsultarDados();
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Fechando programa...");
                        menu = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
            /* Output expected:
            Exemplo 1:

            Entre o número da conta: 5447
            Entre o titular da conta: Milton Gonçalves
            Haverá depósito inicial(s / n) ? s
            Entre o valor de depósito inicial: 350.00

            Dados da conta:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 350.00

            Entre um valor para depósito: 200
            Dados da conta atualizados:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 550.00

            Entre um valor para saque: 199
            Dados da conta atualizados:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 347.50

            Exemplo 2:
            Entre o número da conta: 5139
            Entre o titular da conta: Elza Soares
            Haverá depósito inicial(s / n) ? n

            Dados da conta:
            Conta 5139, Titular: Elza Soares, Saldo: $ 0.00

            Entre um valor para depósito: 300.00
            Dados da conta atualizados:
            Conta 5139, Titular: Elza Soares, Saldo: $ 300.00

            Entre um valor para saque: 298.00
            Dados da conta atualizados:
            Conta 5139, Titular: Elza Soares, Saldo: $ -1.50
            */
        }
    }
}
