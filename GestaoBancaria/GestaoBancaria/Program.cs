using System;

namespace GestaoBancaria
{
    class Program
    {
        static ContaCorrente conta;

        static void Main()
        {
            CriarConta();

            int opcao = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Selecione a opção desejada:");
                Console.WriteLine("1 - Depositar");
                Console.WriteLine("2 - Sacar");
                Console.WriteLine("3 - Consultar saldo");
                Console.WriteLine("4 - Sair");
                var opcaoSelecionada = int.Parse(Console.ReadLine());

                switch (opcaoSelecionada)
                {
                    case 1:
                        Depositar();
                        break;
                    case 2:
                        Sacar();
                        break;
                    case 3:
                        ConsultarSaldo();
                        break;
                    default:
                        return;
                }
            } while (opcao != 4);

            Console.ReadKey();
        }

        private static void ConsultarSaldo()
        {
            Console.WriteLine();
            var saldo = conta.ConsultarSaldo();
            Console.WriteLine($"Saldo disponível {saldo}");
        }

        private static void Sacar()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o valor para saque:");
            var valor = double.Parse(Console.ReadLine());

            var permiteSaque = conta.Sacar(valor);

            while (!permiteSaque)
            {
                Console.WriteLine();
                Console.WriteLine("Valor maior que permitido. Digite outro valor para saque:");
                valor = double.Parse(Console.ReadLine());

                permiteSaque = conta.Sacar(valor);
            }
        }

        private static void Depositar()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o valor para depósito:");
            var valor = double.Parse(Console.ReadLine());
            conta.Depositar(valor);
        }

        private static void CriarConta()
        {
            string nome;

            do
            {
                Console.WriteLine("Digite seu nome para criar a conta: ");
                nome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nome))
                {
                    var cliente = new Cliente(nome);
                    conta = new ContaCorrente(cliente);
                }                
            } while (string.IsNullOrWhiteSpace(nome));
        }
    }

    class ContaCorrente
    {
        public Cliente Cliente { get; }
        public double Valor { get; private set; }

        public ContaCorrente(Cliente cliente)
        {
            Cliente = cliente;
            Valor = 0;
        }

        public void Depositar(double valor)
        {
            Valor += valor;
        }

        public bool Sacar(double valorSaque)
        {
            var saquePermitido = Valor - valorSaque >= 0;
            if (saquePermitido)
            {
                Valor -= valorSaque;
                return true;
            }

            return false;
        }

        public double ConsultarSaldo()
        {
            return Valor;
        }
    }

    class Cliente
    {
        public string Nome { get; }

        public Cliente(string nome)
        {
            Nome = nome;
        }
    }
}
