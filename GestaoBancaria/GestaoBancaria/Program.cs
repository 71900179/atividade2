using System;

namespace GestaoBancaria
{
    class Program
    {
        static ContaCorrente conta;

        static void Main()
        {
            CriarConta();

            Console.ReadKey();
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

        public void Sacar(double valorSaque)
        {
            var saquePermitido = Valor - valorSaque >= 0;
            if (saquePermitido)
            {
                Valor -= valorSaque;
            }
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
