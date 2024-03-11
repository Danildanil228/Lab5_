using System;

public class FractionException : Exception
{
    public FractionException ( string message ) : base(message)
    {
    }
}

public class CustomFractionException : Exception
{
    public int Numerator { get; }
    public int Denominator { get; }

    public CustomFractionException ( string message, int numerator, int denominator ) : base(message)
    {
        Numerator = numerator;
        Denominator = denominator;
    }
}

public static class FractionCalculator
{
    public static int CalculateIntegerPart ( int numerator, int denominator )
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero");
        }

        return numerator / denominator;
    }
    public static int CalculateIntegerPartWithThrow ( int numerator, int denominator )
    {
        if (denominator == 0)
        {
            throw new Exception("Denominator cannot be zero");
        }

        return numerator / denominator;
    }
    public static int CalculateIntegerPartWithSpecificException ( int numerator, int denominator )
    {
        if (denominator == 0)
        {
            throw new DivideByZeroException("Denominator cannot be zero");
        }

        return numerator / denominator;
    }
    public static int CalculateIntegerPartWithCustomException ( int numerator, int denominator )
    {
        if (denominator == 0)
        {
            throw new CustomFractionException("Denominator cannot be zero", numerator, denominator);
        }

        return numerator / denominator;
    }
}

class Program
{
    static void Main ( string[] args )
    {
        try
        {
            Console.Write("Введите числитель: ");
            int numerator = int.Parse(Console.ReadLine());
            Console.Write("Введите знаменатель: ");
            int denominator = int.Parse(Console.ReadLine());
            int result = FractionCalculator.CalculateIntegerPart(numerator, denominator);
            Console.WriteLine("Результат: " + result);
        }
        catch (FractionException ex)
        {
            Console.WriteLine("Поймано исключение FractionException: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Поймано исключение: " + ex.Message);
        }
    }
}
