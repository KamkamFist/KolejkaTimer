// Seeusing System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

class Program
{
    static Queue<string> queue = new Queue<string>();
    static Queue<int> czas = new Queue<int>();

    static void AddClient()
    {
        Console.WriteLine("Podaj imię klienta:");
        string name = Console.ReadLine();

        queue.Enqueue(name);
        czas.Enqueue(0);
        Console.WriteLine("Klient dodany do kolejki");
    }

    static void ServeClient()
    {
        if (queue.Count == 0)
        {
            Console.WriteLine("Kolejka jest pusta!");
            return;
        }

        string name = queue.Dequeue();
        czas.Dequeue();
        Console.WriteLine("Obsłużono klienta: " + name);
    }

    static void ShowQueue()
    {
        Console.WriteLine("W kolejce czekają: " + queue.Count + " osób");
        Console.WriteLine("Są to kolejno:");


        var queueArray = queue.ToArray();
        var czasArray = czas.ToArray();

        for (int i = 0; i < queue.Count; i++)
        {
            Console.WriteLine(queueArray[i] + " - " + czasArray[i] + " sekund");
        }
    }

    public static async Task Main()
    {

        _ = ZwiekszajSekundy();


        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1 - Dodaj klienta");
            Console.WriteLine("2 - Obsłuż klienta");
            Console.WriteLine("3 - Pokaż kolejkę");
            Console.WriteLine("4 - Zakończ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddClient();
                    break;
                case "2":
                    ServeClient();
                    break;
                case "3":
                    ShowQueue();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                    break;
            }
        }
    }

    static async Task ZwiekszajSekundy()
    {
        while (true)
        {
            if (czas.Count > 0)
            {
                int[] czasArray = czas.ToArray();
                for (int i = 0; i < czasArray.Length; i++)
                {
                    czasArray[i]++;
                }


                czas.Clear();
                foreach (var t in czasArray)
                {
                    czas.Enqueue(t);
                }



            }

            await Task.Delay(1000);
        }
    }
}
