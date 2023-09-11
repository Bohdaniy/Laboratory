using System;
using System.Security.Cryptography;
class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 20; i++)
        {
            string randomNumber = Convert.ToBase64String(RandomNumberGenerator.GenerateRandomNumber(32));
            Console.WriteLine(randomNumber);
        }
        Console.ReadLine();
    }
}

public class RandomNumberGenerator
{
    public static byte[] GenerateRandomNumber(int length)
    {
        using (var randomNumberGenerator = new RNGCryptoServiceProvider())
        {
            var randomNumber = new byte[length];
            randomNumberGenerator.GetBytes(randomNumber);
            return randomNumber;
        }
    }
}

