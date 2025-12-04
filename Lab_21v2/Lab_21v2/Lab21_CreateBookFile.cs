using System;
using System.IO;

namespace Lab21_CreateBookFile
{
    class Lab21_CreateBookFile
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            const string fileName = "Book.txt";

            Console.Write("Скільки учнів у класі буде вводити своїх улюблених письменників? ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Помилка. Введіть додатне ціле число: ");
            }

            // Створюємо (перезаписуємо) файл
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"\nУчень №{i + 1}: введіть 3 прізвища улюблених письменників");

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

                        // Записуємо КОЖНЕ прізвище окремим рядком
                        writer.WriteLine(author);
                    }
                }
            }

            Console.WriteLine($"\nФайл \"{fileName}\" успішно створено.");
        }
    }
}
