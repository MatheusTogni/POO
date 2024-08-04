using System;

namespace E1
{
    public class Veiculo
    {
        // Atributos
        private string _marca;
        private string _modelo;

        // Propriedades
        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        // Métodos
        public void Acelerar()
        {
            Console.WriteLine($"{_marca} {_modelo} está acelerando...");
        }

        public void Frear()
        {
            Console.WriteLine($"{_marca} {_modelo} está freando...");
        }

        // Assinaturas
        public virtual void Abastecer()
        {
            Console.WriteLine($"{_marca} {_modelo} está sendo abastecido...");
        }

        public bool Abastecer(string tipoCombustivel)
        {
            Console.WriteLine($"{_marca} {_modelo} está sendo abastecido com {tipoCombustivel}...");
            return true;
        }

        // Método sobrecarga
        public virtual void EmitirSom()
        {
            Console.WriteLine($"{_marca} {_modelo} está emitindo um som padrão...");
        }

        // Construtor
        public Veiculo(string marca, string modelo)
        {
            _marca = marca;
            _modelo = modelo;
        }

        // Classe filha (subclasse)
        public class Carro : Veiculo
        {
            private string _tipoCombustivel;
            private int _quantidadePortas;

            public string TipoCombustivel
            {
                get { return _tipoCombustivel; }
                set { _tipoCombustivel = value; }
            }

            public int QuantidadePortas
            {
                get { return _quantidadePortas; }
                set { _quantidadePortas = value; }
            }

            public void LigarRadio()
            {
                Console.WriteLine($"{Marca} {Modelo} está com o rádio ligado...");
            }

            // Construtor da subclasse
            public Carro(string marca, string modelo, string tipoCombustivel, int quantidadePortas) : base(marca, modelo)
            {
                _tipoCombustivel = tipoCombustivel;
                _quantidadePortas = quantidadePortas;
            }

            // Sobrescrita de método
            public override void EmitirSom()
            {
                Console.WriteLine($"{Marca} {Modelo} está emitindo o som do carro...");
            }

            public override void Abastecer()
            {
                Console.WriteLine($"{Marca} {Modelo} está sendo abastecido com {TipoCombustivel}...");
            }
        }
    }
}
