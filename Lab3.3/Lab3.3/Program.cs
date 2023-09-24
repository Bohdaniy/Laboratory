using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string filetext = "D:\\labitos2\\Lab3\\main.dat";
        string fileContent = File.ReadAllText(filetext);
        Console.WriteLine("Змiст файлу:");
        Console.WriteLine(fileContent);
        if (File.Exists(filetext))
        {
            var bytes = Encoding.UTF8.GetBytes("Mit21");
            string text = "D:\\labitos2\\Lab3\\main.dat";
            var filetextt = File.ReadAllBytes(text);
            var key = new byte[5];
            for (int i = 0; i <= filetextt.Length - 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    key[j] = (byte)(filetextt[i + j] ^ bytes[j]);
                }

                var decryptedText = DecryptedText(key, filetextt, i);

                if (Contains(decryptedText))
                {
                    Console.WriteLine($"{i} Дешифрований текст: {Encoding.UTF8.GetString(decryptedText)}");
                }

            }

        }
    }
        public static byte[] DecryptedText(byte[] key, byte[] filetextt, int index)
        {
            var decryptedText = new byte[filetextt.Length];

            for (int i = index; i < filetextt.Length; i += key.Length)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (i + j > decryptedText.Length - 1)
                    {
                        break;
                    }
                    decryptedText[i + j] = (byte)(filetextt[i + j] ^ key[j]);
                }
            }
            index -= 1;
            for (int a = index; a >= 0;)
            {
                for (int i = key.Length - 1; i >= 0; i--)
                {
                    if (a < 0)
                    {
                        break;
                    }
                    decryptedText[a] = (byte)(filetextt[a] ^ key[i]);
                    a--;
                }
            }

            return decryptedText;
        }

        public static bool Contains(byte[] mesage)
        {
            var mit = Encoding.UTF8.GetString(mesage);
            return mit.Contains("Mit21");
        }
    }



