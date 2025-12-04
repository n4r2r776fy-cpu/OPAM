using System;

namespace Lab17_Task3
{
    struct DictionaryEntry
    {
        public string English;
        public string Ukrainian;
        public string Russian;

        public DictionaryEntry(string eng, string ua, string ru)
        {
            English = eng;
            Ukrainian = ua;
            Russian = ru;
        }

        public void Info()
        {
            Console.WriteLine($"ENG: {English}");
            Console.WriteLine($"UKR: {Ukrainian}");
            Console.WriteLine($"RUS: {Russian}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            DictionaryEntry[] dict =
            {
                new DictionaryEntry("computer", "комп'ютер", "компьютер"),
                new DictionaryEntry("mouse", "миша", "мышь"),
                new DictionaryEntry("keyboard", "клавіатура", "клавиатура"),
                new DictionaryEntry("screen", "екран", "экран"),
                new DictionaryEntry("network", "мережа", "сеть"),
                new DictionaryEntry("database", "база даних", "база данных")
            };

            Console.Write("Введіть англійське слово для пошуку: ");
            string word = Console.ReadLine();

            bool found = false;

            foreach (var entry in dict)
            {
                if (string.Equals(entry.English, word,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nЗнайдено:");
                    entry.Info();
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Такого слова в словнику немає.");
            }

            Console.WriteLine("\nНатисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}
