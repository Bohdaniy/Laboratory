using System;
using System.IO;
using System.Text;

class Program
{
     
    static void Main()
    {
        string filetext = "D:\\labitos2\\Lab3\\text.txt";
            string fileContent = File.ReadAllText(filetext);
            Console.WriteLine("Змiст файлу:");
            Console.WriteLine(fileContent);
            Console.WriteLine("Введiть ключ:");
            string key = Console.ReadLine();

        try
        {

           
            
            if (File.Exists(filetext))
            {
                byte[] textBytes = Encoding.UTF8.GetBytes(fileContent);
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);

                byte[] encryptedText = new byte[textBytes.Length];

                for (int i = 0; i < textBytes.Length; i++)
                {
                    encryptedText[i] = (byte)(textBytes[i] ^ keyBytes[i % keyBytes.Length]);
                }

                using (FileStream stream = new FileStream("D:\\labitos2\\Lab3\\main.dat", FileMode.OpenOrCreate))
                {
                    stream.Write(encryptedText, 0, encryptedText.Length);
                }

                Console.WriteLine("Текст був записаний у новий файл ");
                string newFiletext = "D:\\labitos2\\Lab3\\main.dat";
                string newfileContent = File.ReadAllText(newFiletext);
                Console.WriteLine(newfileContent);
                Console.WriteLine("Чи бажаєте ви розшифрувати текст(y/n): ");
                 char g = Console.ReadLine()[0];
                if(g=='y' || g=='Y'){
                    
                    string FilePath = "D:\\labitos2\\Lab3\\main.dat";
                    if (File.Exists(FilePath))
                    {
                        
                        byte[] KeyBytess = Encoding.UTF8.GetBytes(key);

                        byte[] decryptedText;

                        using (FileStream stream = new FileStream("D:\\labitos2\\Lab3\\main.dat", FileMode.Open))
                        {
                            decryptedText = new byte[stream.Length];
                            stream.Read(decryptedText, 0, (int)stream.Length);
                        }

                        byte[] Text = new byte[decryptedText.Length];

                        for (int i = 0; i < decryptedText.Length; i++)
                        {
                            Text[i] = (byte)(decryptedText[i] ^ KeyBytess[i % KeyBytess.Length]);
                        }

                        string text = Encoding.UTF8.GetString(Text);

                        Console.WriteLine("Розшифрований текст: " + text);
                    }
                }
                else if (g == 'n' || g=='N')
                {
                    Console.WriteLine("До побачення!");
                    Environment.Exit(0);


                }
            }
            else
            {
                Console.WriteLine("Файл не знайдено.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        

        
    }


}