using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Lab21_ProcessBookFile
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            const string fileName = "Book.txt";

            // Перевірка існування файла
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"Файл \"{fileName}\" не знайдено. " +
                                  "Спочатку запустіть програму створення файла.");
                return;
            }

            string[] lines = File.ReadAllLines(fileName);

            if (lines.Length == 0)
            {
                Console.WriteLine("Файл порожній. Даних про письменників немає.");
                return;
            }

            // Словник: прізвище → кількість голосів
            Dictionary<string, int> freq = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (string raw in lines)
            {
                string author = raw.Trim();

                if (string.IsNullOrWhiteSpace(author))
                    continue;

                if (freq.ContainsKey(author))
                    freq[author]++;
                else
                    freq[author] = 1;
            }

            if (freq.Count == 0)
            {
                Console.WriteLine("У файлі немає коректних прізвищ.");
                return;
            }

            // Сортуємо: спочатку за кількістю (спадання), потім за алфавітом
            var topAuthors = freq
                .OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key)
                .Take(5)
                .ToList();

            Console.WriteLine("П'ять найпопулярніших письменників:\n");
            Console.WriteLine("{0,-25} {1,10}", "Письменник", "Кількість");
            Console.WriteLine(new string('-', 37));

            foreach (var item in topAuthors)
            {
                Console.WriteLine("{0,-25} {1,10}", item.Key, item.Value);
            }

            Console.WriteLine(new string('-', 37));

            Console.WriteLine($"\nУсього різних письменників: {freq.Count}");
        }
    }
}

