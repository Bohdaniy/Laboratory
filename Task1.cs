using System;
class Program
{
    static void Main()
    {
        Random random1 = new Random(1234);
        Random random2 = new Random(5678);

        Console.WriteLine("Послідовність для генератора 1:");
        for (int ctr = 0; ctr < 10; ctr++)
        {
            Console.Write("{0,3} ", random1.Next(1, 10));
        }

        Console.WriteLine("\nПослідовність для генератора 2:");
        for (int ctr = 0; ctr < 10; ctr++)
        {
            Console.Write("{0,3} ", random2.Next(1, 10));
        }

        Console.ReadKey();



    }
}
