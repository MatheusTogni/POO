using System;
using E1;

class Program
{
    static void Main(string[] args)
    {
        var veiculo = new Veiculo("Ford", "Fiesta");
        veiculo.Acelerar();
        veiculo.Frear();
        veiculo.Abastecer();
        veiculo.EmitirSom();
        Console.WriteLine(veiculo);

        Veiculo.Carro meuCarro = new Veiculo.Carro("Chevrolet", "Corsa", "Gasolina", 4);
        meuCarro.Acelerar();
        meuCarro.Frear();
        meuCarro.Abastecer();
        meuCarro.EmitirSom();
        meuCarro.LigarRadio();
        Console.WriteLine(meuCarro);
    }
}
