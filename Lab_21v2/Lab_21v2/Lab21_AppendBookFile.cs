using System;
using System.IO;

namespace Lab21_AppendBookFile
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            const string fileName = "Book.txt";

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"Файл \"{fileName}\" не знайдено. " +
                                  "Спочатку запустіть програму створення файла.");
                return;
            }

            Console.Write("Скільки додаткових учнів буде вводити своїх улюблених письменників? ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Помилка. Введіть додатне ціле число: ");
            }

            // Дозапис у кінець файла
            using (StreamWriter writer = new StreamWriter(fileName, true)) // append = true
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"\nНовий учень №{i + 1}: введіть 3 прізвища улюблених письменників");

                    for (int j = 0; j < 3; j++)
                    {
                        string author;
                        while (true)
                        {
                            Console.Write($"  Письменник {j + 1}: ");
                            author = Console.ReadLine()?.Trim();

                            if (!string.IsNullOrWhiteSpace(author))
                                break;

                            Console.WriteLine("  Помилка. Прізвище не може бути порожнім.");
                        }

                        writer.WriteLine(author);
                    }
                }
            }

            Console.WriteLine($"\nДані успішно додано до файла \"{fileName}\".");
            Console.WriteLine("Тепер ще раз запустіть програму обробки, щоб побачити оновлений топ-5.");
        }
    }
}
