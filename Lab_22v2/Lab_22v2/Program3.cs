using System;
using System.IO;
using System.Text;

class Program3
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        string fileName = "Book.dat";

        if (!File.Exists(fileName))
        {
            Console.WriteLine($"Файл \"{fileName}\" не знайдено.");
            Console.WriteLine("Спочатку створіть його першою програмою.");
            Console.WriteLine("Натисніть Enter для виходу...");
            Console.ReadLine();
            return;
        }

        Console.Write("Скільки ще учнів вводитимуть своїх улюблених письменників? ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Помилка. Введіть додатне ціле число: ");
        }

        using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
        using (BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8))
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"\nНовий учень №{i}: введіть 3 прізвища улюблених письменників:");
                for (int j = 1; j <= 3; j++)
                {
                    string surname;
                    while (true)
                    {
                        Console.Write($"  Прізвище {j}: ");
                        surname = Console.ReadLine().Trim();
                        if (!string.IsNullOrWhiteSpace(surname))
                            break;
                        Console.WriteLine("  Прізвище не може бути порожнім. Спробуйте ще раз.");
                    }

                    bw.Write(surname);
                }
            }
        }

        Console.WriteLine($"\nНові дані успішно дозаписані у файл \"{fileName}\".");
        Console.WriteLine("Тепер знову запустіть програму обробки (№2), щоб побачити оновлену статистику.");
        Console.WriteLine("Натисніть Enter для виходу...");
        Console.ReadLine();
    }
}
