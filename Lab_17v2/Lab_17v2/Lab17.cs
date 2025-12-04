using System;

namespace Lab17
{
    struct Student
    {
        public string Surname;
        public string Name;
        public string Patronymic;

        // Конструктор №1 – введення даних з консолі
        public Student(bool readFromConsole)
        {
            Console.Write("Введіть прізвище: ");
            Surname = Console.ReadLine();

            Console.Write("Введіть ім'я: ");
            Name = Console.ReadLine();

            Console.Write("Введіть по батькові: ");
            Patronymic = Console.ReadLine();
        }

        // Конструктор №2 – ініціалізація переданими даними
        public Student(string surname, string name, string patronymic)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
        }

        // Метод для виводу інформації
        public void Info()
        {
            Console.WriteLine($"{Surname} {Name} {Patronymic}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // ===== Завдання 1: один елемент =====
            Student one;
            one.Surname = "Іванов";
            one.Name = "Іван";
            one.Patronymic = "Іванович";

            Console.WriteLine("Один студент (завдання 1):");
            one.Info();
            Console.WriteLine();

            // ===== Завдання 2: масив структур з ініціалізатором =====

            // Масив не менше 5 елементів:
            // 1,2 – прямий ініціалізатор полів
            // 3,4 – через конструктор з параметрами
            // 5 – через конструктор, що читає з консолі
            Student[] group = new Student[5];

            // 1: безпосередня ініціалізація
            group[0] = new Student
            {
                Surname = "Петренко",
                Name = "Іван",
                Patronymic = "Олегович"
            };

            // 2: безпосередня ініціалізація
            group[1] = new Student
            {
                Surname = "Коваль",
                Name = "Марія",
                Patronymic = "Сергіївна"
            };

            // 3: конструктор із параметрами
            group[2] = new Student("Сидоренко", "Іван", "Петрович");

            // 4: конструктор із параметрами
            group[3] = new Student("Гончарук", "Олексій", "Іванович");

            // 5: конструктор, що читає з консолі
            Console.WriteLine("Введення даних для 5-го студента:");
            group[4] = new Student(true);

            // Пошук студентів з вказаним ім'ям (варіант 2)
            Console.Write("\nВведіть ім'я для пошуку: ");
            string searchName = Console.ReadLine();

            bool found = false;
            Console.WriteLine($"\nСтуденти з ім'ям \"{searchName}\":");

            foreach (Student st in group)
            {
                if (string.Equals(st.Name, searchName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    st.Info();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Студентів з таким ім'ям не знайдено.");
            }

            Console.WriteLine("\nНатисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}
