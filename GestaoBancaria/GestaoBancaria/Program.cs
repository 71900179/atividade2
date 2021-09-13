using System;

namespace GestaoBancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
        public string Nome { get; set; }
    }
}
