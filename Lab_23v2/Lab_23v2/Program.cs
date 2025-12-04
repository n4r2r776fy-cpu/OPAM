using System;
using System.IO;
using System.Text;

class Program
{
    const int FieldLength = 20; // кількість символів на одне поле

    static string FixField(string input, int length)
    {
        if (input == null) input = "";
        input = input.Trim();
        if (input.Length > length)
            input = input.Substring(0, length);
        return input.PadRight(length); // доповнюємо пробілами до фіксованої довжини
    }

    [STAThread]
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        string fileName = "students.dat";

        Console.Write("Введіть кількість студентів: ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Помилка. Введіть додатне ціле число: ");
        }

        using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        using (BinaryWriter bw = new BinaryWriter(fs, Encoding.Unicode))
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"\nСтудент №{i}");

                string surname, name, patronymic;

                // Прізвище
                while (true)
                {
                    Console.Write("  Прізвище: ");
                    surname = Console.ReadLine().Trim();
                    if (!string.IsNullOrWhiteSpace(surname))
                        break;
                    Console.WriteLine("  Прізвище не може бути порожнім.");
                }

                // Ім'я
                while (true)
                {
                    Console.Write("  Ім'я: ");
                    name = Console.ReadLine().Trim();
                    if (!string.IsNullOrWhiteSpace(name))
                        break;
                    Console.WriteLine("  Ім'я не може бути порожнім.");
                }

                // По батькові
                while (true)
                {
                    Console.Write("  По батькові: ");
                    patronymic = Console.ReadLine().Trim();
                    if (!string.IsNullOrWhiteSpace(patronymic))
                        break;
                    Console.WriteLine("  По батькові не може бути порожнім.");
                }

                // Фіксуємо довжину полів і записуємо у файл
                bw.Write(FixField(surname, FieldLength).ToCharArray());
                bw.Write(FixField(name, FieldLength).ToCharArray());
                bw.Write(FixField(patronymic, FieldLength).ToCharArray());
            }
        }

        Console.WriteLine($"\nФайл \"{fileName}\" успішно створено.");
        Console.WriteLine("Натисніть Enter для виходу...");
        Console.ReadLine();
    }
}
