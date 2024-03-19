using System;

class MainClass
{
    public static void Main(string[] args)
    {
        Console.Write("введите количество нулей (a): ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("введите количество однерок (b): ");
        int b = Convert.ToInt32(Console.ReadLine());
        int result = CountSequences(a, b);
        Console.WriteLine($"Последовательность: {result}");

        Console.Write("Хотите вывести примеры последователдьностей? (да/нет): ");
        string response = Console.ReadLine();

        if (response.ToLower() == "да")
        {
            GenerateSequences("", a, b);
        }
    }

    static int CountSequences(int a, int b)
    {
        if (a == b)
        {
            return a + 1;
        }

        if (a > b + 1)
        {
            return 0;
        }

        int result = 1;
        for (int i = 0; i < a; i++)
        {
            result *= (b - i);
            result /= (i + 1);
        }
        return result;
    }

    static void GenerateSequences(string sequence, int zerosRemaining, int onesRemaining)
    {
        if (zerosRemaining == 0 && onesRemaining == 0)
        {
            Console.WriteLine(sequence);
            return;
        }

        if (sequence.Length > 0 && sequence[^1] == '0')
        {
            GenerateSequences(sequence + "1", zerosRemaining, onesRemaining - 1);
        }
        else
        {
            if (zerosRemaining > 0)
            {
                GenerateSequences(sequence + "0", zerosRemaining - 1, onesRemaining);
            }
            if (onesRemaining > 0)
            {
                GenerateSequences(sequence + "1", zerosRemaining, onesRemaining - 1);
            }
        }
    }
}