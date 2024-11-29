using System;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria {
        public int NumeroConta { get; set; }
        public string NomeTitular { get; set; }
        public double Deposito { get; set; }
        private double Saldo { get; set; }
        private const double Taxa = 3.50;
        private string Senha { get; set; }
        public ContaBancaria(int numeroConta, string nomeTitular, string senha, double deposito = 0)
        {
            NumeroConta = numeroConta;
            NomeTitular = nomeTitular;
            Saldo = deposito;
            Senha = senha;
        }
        
        public void Depositar(double valor)
        {
            Console.WriteLine("Informe a senha para confirmar a operaçao: ");
            string senha = Console.ReadLine();
            if (senha.Equals(Senha))
            {
                if (valor > 0)
                {
                    Saldo += valor;
                    Console.WriteLine($"Depósito realizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Por favor informe um valor de deposito maior do que zero!");
                }
            }
            else
            {
                Console.WriteLine("Senha incorreta! Nao foi possivel realizar a operaçao");
            }

        }

        public void Sacar(double valor)
        {
            Console.WriteLine("Informe a senha para confirmar a operaçao: ");
            string senha = Console.ReadLine();
            if (senha.Equals(Senha))
            {
                if (valor > 0)
                {
                    double descontos = valor + Taxa;
                    char confimacao;
                    Console.WriteLine($"Informamos que será descontado do seu saldo o valor de {descontos}.\n Saque = {valor}\n Taxa de servico = {Taxa} \nDeseja prosseguir?[S/N]");
                    confimacao = char.Parse(Console.ReadLine());
                    if (confimacao == 'S' || confimacao == 's')
                    {
                        Saldo -= descontos;
                        Console.WriteLine($"Saque realizado com sucesso!");
                    }
                }
                else
                {
                    Console.WriteLine("Por favor informe um valor maior que zero!");
                }
            }
            else
            {
                Console.WriteLine("Senha incorreta! Nao foi possivel realizar a operaçao");
            }
            
        }

        public void ConsultarDados()
        {
            Console.WriteLine("\n--- Dados da Conta ---");
            Console.WriteLine($"Número da Conta: {NumeroConta}");
            Console.WriteLine($"Titular: {NomeTitular}");
            Console.WriteLine($"Saldo: ${Saldo:F2}");
        }
    }
}
