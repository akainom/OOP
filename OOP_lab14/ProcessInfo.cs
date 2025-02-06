using System;
using System.IO;
using System.Diagnostics;
using System.Threading;

class Program
{
    static int n; 
    static Mutex mutex = new Mutex();
    static ManualResetEvent evenTurn = new ManualResetEvent(false); 
    static ManualResetEvent oddTurn = new ManualResetEvent(true); 

    static void Main()
    {
        // Задача 1: Вывод информации о процессах
        OutputProcessInfo();

        // Задача 2: Исследование текущего домена приложения
        InvestigateAppDomain();

        // Задача 3: Создание потока для записи чисел
        CreateAndRunThreadForNumbers();

        // Задача 4: Создание двух потоков для вывода четных и нечетных чисел
        CreateAndRunThreadsForEvenOddNumbers();

        // Задача 5: Повторяющаяся задача на основе класса Timer
        CreateRecurringTaskWithTimer();

        Console.ReadLine();  // Ожидаем завершения работы
    }

    // Задача 1: Вывод информации о процессах
    static void OutputProcessInfo()
    {
        var processes = Process.GetProcesses();
        using (StreamWriter file = new StreamWriter("processes.txt"))
        {
            foreach (var process in processes)
            {
                try
                {
                    file.WriteLine($"ID: {process.Id}, Name: {process.ProcessName}, Priority: {process.BasePriority}, " +
                                    $"Start Time: {process.StartTime}, Status: {process.Responding}, CPU Time: {process.TotalProcessorTime}");
                    Console.WriteLine($"ID: {process.Id}, Name: {process.ProcessName}, Priority: {process.BasePriority}, " +
                                       $"Start Time: {process.StartTime}, Status: {process.Responding}, CPU Time: {process.TotalProcessorTime}");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"Access denied to process {process.ProcessName} (ID: {process.Id}). Skipping.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving info for process {process.ProcessName} (ID: {process.Id}): {ex.Message}");
                }
            }
        }
    }

    // Задача 2: Исследование текущего домена приложения
    static void InvestigateAppDomain()
    {
        var currentDomain = AppDomain.CurrentDomain;
        Console.WriteLine($"Current Domain: {currentDomain.FriendlyName}");
        Console.WriteLine($"Application Base: {currentDomain.SetupInformation.ApplicationBase}");

        // Выводим загруженные сборки
        Console.WriteLine("Loaded Assemblies:");
        foreach (var assembly in currentDomain.GetAssemblies())
        {
            Console.WriteLine(assembly.FullName);
        }
    }

    // Задача 3: Создание потока для записи чисел
    static void CreateAndRunThreadForNumbers()
    {
        Console.Write("Enter n for numbers: ");
        int n = int.Parse(Console.ReadLine());

        Thread thread = new Thread(() => PrintNumbers(n));
        thread.Start();

        thread.Join();  // Ждем завершения потока
    }

    static void PrintNumbers(int input)
    {
        n = input;
        List<int> numbers = new List<int>();
        for (int i = 2; i < n; i++)
        {
            numbers.Add(i);
        }
        for (int i = 0; i < numbers.Count; i++)
        {
            for (int j = 2; j < n; j++)
            {
                numbers.Remove(numbers[i] * j);
            }
        }
        Console.WriteLine(string.Join(",", numbers));
    }

    // Задача 4: Создание двух потоков для вывода четных и нечетных чисел

    static void CreateAndRunThreadsForEvenOddNumbers()
    {
        Thread evenThread = new Thread(PrintEvenNumbers);
        Thread oddThread = new Thread(PrintOddNumbers);
        Thread evenOdd = new Thread(PrintEvenOdd);

        oddThread.Priority = ThreadPriority.Highest;

        evenThread.Start();
        oddThread.Start();

        evenThread.Join();
        oddThread.Join();
    }

    static void PrintEvenNumbers()
    {
        string even = "Even: ";
        for (int i = 2; i <= n; i += 2)
        {
            if (i > n)
            {
                break;
            }
            evenTurn.WaitOne();
            mutex.WaitOne();
            even += i + " ";
            using (StreamWriter file = new StreamWriter("numbers.txt", true))
            {
                file.WriteLine(i);
            }
            mutex.ReleaseMutex();
            oddTurn.Set();
            evenTurn.Reset();
            Thread.Sleep(200);
        }
        Console.WriteLine(even);
    }

    static void PrintOddNumbers()
    {
        string odd = "Odd: ";
        for (int i = 1; i <= n; i += 2)
        {
            if (i > n) break;
            oddTurn.WaitOne();
            mutex.WaitOne();
            odd += i + " ";
            using (StreamWriter file = new StreamWriter("numbers.txt", true))
            {
                file.WriteLine(i);
            }
            mutex.ReleaseMutex();
            evenTurn.Set();
            oddTurn.Reset();
            Thread.Sleep(300);
        }
        Console.WriteLine(odd);
    }

    static void PrintEvenOdd()
    {
        using (StreamWriter writer = new StreamWriter("file.txt")) ;
        Thread thread1 = new Thread(task4_1);
        Thread thread2 = new Thread(task4_2);

        thread1.Priority = ThreadPriority.Highest;
        thread1.Start();
        thread2.Start();

        void task4_1()
        {
            for (int i = 0; i <= n; i += 2)
            {
                Console.WriteLine(i);

                Thread.Sleep(100);
            }
        }
        void task4_2()
        {
            thread1.Join();
            for (int i = 1; i <= n; i += 2)
            {

                Console.WriteLine(i);

                Thread.Sleep(400);
            }
        }
    }

    // Задача 5: Повторяющаяся задача на основе класса Timer
    static void CreateRecurringTaskWithTimer()
    {
        TimerCallback callback = new TimerCallback(ExecuteTask);
        Timer timer = new Timer(callback, null, 0, 1000);  // Интервал 1 секунда
    }

    static void ExecuteTask(object state)
    {
        Console.WriteLine($"Task executed at {DateTime.Now}");
    }
}
