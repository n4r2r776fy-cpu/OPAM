using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        string fileName = "Book.dat";

        Console.Write("Введіть кількість учнів: ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Помилка. Введіть додатне ціле число: ");
        }

        using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        using (BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8))
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"\nУчень №{i}: введіть 3 прізвища улюблених письменників:");

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

                    // Записуємо прізвище як рядок у двійковий файл
                    bw.Write(surname);
                }
            }
        }

        Console.WriteLine($"\nФайл \"{fileName}\" успішно створено.");
        Console.WriteLine("Натисніть Enter для виходу...");
        Console.ReadLine();
    }
}
