using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Program2
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        string fileName = "Book.dat";

        // Перевірка існування файла
        if (!File.Exists(fileName))
        {
            Console.WriteLine($"Файл \"{fileName}\" не знайдено.");
            Console.WriteLine("Спочатку виконайте програму формування файла.");
            Console.WriteLine("Натисніть Enter для виходу...");
            Console.ReadLine();
            return;
        }

        Dictionary<string, int> freq = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        using (BinaryReader br = new BinaryReader(fs, Encoding.UTF8))
        {
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                string surname = br.ReadString();

                if (freq.ContainsKey(surname))
                    freq[surname]++;
                else
                    freq[surname] = 1;
            }
        }

        if (freq.Count == 0)
        {
            Console.WriteLine("Файл порожній або не містить прізвищ.");
        }
        else
        {
            var top5 = freq
                .OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key)
                .Take(5)
                .ToList();

            Console.WriteLine("П'ять найпопулярніших письменників:\n");
            int rank = 1;
            foreach (var item in top5)
            {
                Console.WriteLine($"{rank}. {item.Key} — {item.Value} раз(и)");
                rank++;
            }
        }

        Console.WriteLine("\nНатисніть Enter для виходу...");
        Console.ReadLine();
    }
}
