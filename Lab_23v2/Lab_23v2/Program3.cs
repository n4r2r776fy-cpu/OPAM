using System;
using System.IO;
using System.Text;

class Program3
{
    const int FieldLength = 20;

    static string FixField(string input, int length)
    {
        if (input == null) input = "";
        input = input.Trim();
        if (input.Length > length)
            input = input.Substring(0, length);
        return input.PadRight(length);
    }

    [STAThread]
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        string fileName = "students.dat";

        if (!File.Exists(fileName))
        {
            Console.WriteLine($"Файл \"{fileName}\" не знайдено.");
            Console.WriteLine("Спочатку створіть його першою програмою.");
            Console.WriteLine("Натисніть Enter для виходу...");
            Console.ReadLine();
            return;
        }

        Console.Write("Скільки студентів дозаписати у файл? ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Помилка. Введіть додатне ціле число: ");
        }

        using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
        using (BinaryWriter bw = new BinaryWriter(fs, Encoding.Unicode))
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"\nНовий студент №{i}");

                string surname, name, patronymic;

                while (true)
                {
                    Console.Write("  Прізвище: ");
                    surname = Console.ReadLine().Trim();
                    if (!string.IsNullOrWhiteSpace(surname))
                        break;
                    Console.WriteLine("  Прізвище не може бути порожнім.");
                }

                while (true)
                {
                    Console.Write("  Ім'я: ");
                    name = Console.ReadLine().Trim();
                    if (!string.IsNullOrWhiteSpace(name))
                        break;
                    Console.WriteLine("  Ім'я не може бути порожнім.");
                }

                while (true)
                {
                    Console.Write("  По батькові: ");
                    patronymic = Console.ReadLine().Trim();
                    if (!string.IsNullOrWhiteSpace(patronymic))
                        break;
                    Console.WriteLine("  По батькові не може бути порожнім.");
                }

                bw.Write(FixField(surname, FieldLength).ToCharArray());
                bw.Write(FixField(name, FieldLength).ToCharArray());
                bw.Write(FixField(patronymic, FieldLength).ToCharArray());
            }
        }

        Console.WriteLine($"\nНові дані успішно дозаписані у файл \"{fileName}\".");
        Console.WriteLine("Тепер запустіть програму обробки (№2), щоб побачити оновлений результат.");
        Console.WriteLine("Натисніть Enter для виходу...");
        Console.ReadLine();
    }
}
