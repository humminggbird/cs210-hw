using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Hello World! This is the Fractions Project.");

        Fraction frac1 = new Fraction();

        //I gave no parameters, so it should use constructor 1
        Console.WriteLine(frac1.GetFractionString());
        Console.WriteLine(frac1.GetDecimalValue());

        // I gave one parameter, which is a whole number, so it should use constructor 2
        Fraction frac2 = new Fraction(5);

        Console.WriteLine(frac2.GetFractionString());
        Console.WriteLine(frac2.GetDecimalValue());

        // I gave two parameters, so it should use constructor 3.
        Fraction frac3 = new Fraction(3, 4);

        Console.WriteLine(frac3.GetFractionString());
        Console.WriteLine(frac3.GetDecimalValue());


        Fraction frac4 = new Fraction(1, 3);

        Console.WriteLine(frac4.GetFractionString());
        Console.WriteLine(frac4.GetDecimalValue());


        
        Fraction frac5 = new Fraction();

        frac5.SetTop(7);
        frac5.SetBottom(8);

        Console.WriteLine(frac5.GetTop());
        Console.WriteLine(frac5.GetBottom());

        Console.WriteLine(frac5.GetFractionString());
        Console.WriteLine(frac5.GetDecimalValue());
    }
}