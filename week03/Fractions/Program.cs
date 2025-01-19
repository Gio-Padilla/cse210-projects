using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello World! This is the Fractions Project.");

        Fraction theFraction1 = new Fraction();
        Console.WriteLine(theFraction1.GetFractionString());
        Console.WriteLine(theFraction1.GetDecimalValue());

        Fraction theFraction2 = new Fraction(5);
        Console.WriteLine(theFraction2.GetFractionString());
        Console.WriteLine(theFraction2.GetDecimalValue());

        Fraction theFraction3 = new Fraction(3, 4);
        Console.WriteLine(theFraction3.GetFractionString());
        Console.WriteLine(theFraction3.GetDecimalValue());

        Fraction theFraction4 = new Fraction(1, 3);
        Console.WriteLine(theFraction4.GetFractionString());
        Console.WriteLine(theFraction4.GetDecimalValue());
    }
}