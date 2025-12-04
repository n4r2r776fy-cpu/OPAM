using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xceed.Wpf.Toolkit;


class Program2
{
    const int FieldLength = 20;
    const int RecordChars = FieldLength * 3; // 3 поля
    const int RecordSize = RecordChars * 2;  // char = 2 байти

    public static object MessageBoxButtons { get; private set; }

    private static MessageBox GetMessageBox()
    {
        return MessageBox;
    }

    [STAThread]
    static void Main(MessageBox messageBox)
    {
        string fileName = "students.dat";

        if (!File.Exists(fileName))
        {
            MessageBox.Show(
                $"Файл \"{fileName}\" не знайдено.\nСпочатку створіть його першою програмою.",
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        Dictionary<string, List<(string Name, string Patronymic)>> data =
            new Dictionary<string, List<(string, string)>>(StringComparer.OrdinalIgnoreCase);

        using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        using (BinaryReader br = new BinaryReader(fs, Encoding.Unicode))
        {
            long recordCount = fs.Length / RecordSize;

            for (long i = 0; i < recordCount; i++)
            {
                char[] surnameChars = br.ReadChars(FieldLength);
                char[] nameChars = br.ReadChars(FieldLength);
                char[] patrChars = br.ReadChars(FieldLength);

                string surname = new string(surnameChars).Trim();
                string name = new string(nameChars).Trim();
                string patronymic = new string(patrChars).Trim();

                if (!data.ContainsKey(surname))
                    data[surname] = new List<(string, string)>();

                data[surname].Add((name, patronymic));
            }
        }

        var homonyms = data.Where(p => p.Value.Count > 1).ToList();

        StringBuilder sb = new StringBuilder();

        if (homonyms.Count == 0)
        {
            sb.AppendLine("Однофамільців у списку не виявлено.");
        }
        else
        {
            sb.AppendLine("Однофамільці у списку студентів:\n");

            foreach (var item in homonyms)
            {
                sb.AppendLine($"Прізвище: {item.Key}");
                int k = 1;
                foreach (var st in item.Value)
                {
                    sb.AppendLine($"  {k}. {item.Key} {st.Name} {st.Patronymic}");
                    k++;
                }
                sb.AppendLine();
            }
        }

        messageBox.Show(sb.ToString(), "Результат обробки файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
