// === Понятия ===

// Поток (Thread) (Размещение и выполнение кода)

// Процесс (Process) (Ограничение ресурсов, включение потоков)

// Адресное пространство (Memory scope)

// Ресурсы (resources)

// Приложение (Application)

// Сборка (Assembly)

// Модуль (Module)



// === Процесс ===
// 1. Memory scope
// 2. PID
// 3. Исполняемый код
// 4. Контекст системы безопасности
// 5. Переменные окружения
// 6. Приоритет
// 7. Как минимум один поток
// 8. Системные дискрипторы



//using System.Diagnostics;

//Process[] processes = Process.GetProcesses();

//var orderedProcesses = from p in processes
//                       orderby p.Id
//                       select p;

//foreach (Process p in orderedProcesses)
//    Console.WriteLine($"id: {p.Id}, name: {p.ProcessName}");


using System.Diagnostics;

void Start()
{
    string? input;
    while(true)
    {
        Console.WriteLine("\n\n1. Show all processes");
        Console.WriteLine("2. Get process by PID");
        Console.WriteLine("3. Get process threads");
        Console.WriteLine("4. Get modules");
        Console.WriteLine("5. Start process");
        Console.WriteLine("6. Kill process");

        input = Console.ReadLine();

        switch (input)
        {
            case "1":
                ShowAllProcesses();
                break;
            case "2":
                GetProcessByPID();
                break;
            case "3":
                GetProcessThreads();
                break;
            case "4":
                GetModules();
                break;
            case "5":
                StartProcess();
                break;
            case "6":
                KillProcess();
                break;
        }
    }
}

void ShowError(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
}
void ShowAllProcesses()
{
    Process[] processes = Process.GetProcesses();

    var orderedProcesses = processes.OrderBy(p => p.Id);

    foreach (Process p in orderedProcesses)
        Console.WriteLine($"id: {p.Id} {p.ProcessName}");

}
void GetProcessByPID()
{
    Console.Write("Enter process PID: ");
    string? input = Console.ReadLine();

    try
    {
        if (input is null)
        {
            Console.WriteLine();
            return;
        }
            
        int pid = int.Parse(input);

        Process p = Process.GetProcessById(pid);

        Console.WriteLine($"{p.Id}\t{p.ProcessName}\t{p.BasePriority}\t{p.StartTime}");

    }
    catch (Exception ex)
    {
        ShowError(ex.Message);
    }
}
void GetProcessThreads()
{
    Console.Write("Enter process PID: ");
    string? input = Console.ReadLine();

    try
    {
        if (input is null)
        {
            Console.WriteLine();
            return;
        }

        int pid = int.Parse(input);

        Process p = Process.GetProcessById(pid);

        ProcessThreadCollection threads = p.Threads;

        Console.WriteLine("Threads info:");
        foreach(ProcessThread t in threads)
            Console.WriteLine($"{t.Id} {t.StartTime.ToShortTimeString()} {t.PriorityLevel}");

    }
    catch (Exception ex)
    {
        ShowError(ex.Message);
    }
}
void GetModules()
{
    Console.Write("Enter process PID: ");
    string? input = Console.ReadLine();

    try
    {
        if (input is null)
        {
            Console.WriteLine();
            return;
        }

        int pid = int.Parse(input);

        Process p = Process.GetProcessById(pid);

        ProcessModuleCollection modules = p.Modules;

        foreach (ProcessModule m in modules)
            Console.WriteLine($"{m.ModuleName} {m.ModuleMemorySize}");

    }
    catch (Exception ex)
    {
        ShowError(ex.Message);
    }
}
void StartProcess()
{
    // Process.Start("notepad");

    Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", @"https://en.wikipedia.org/wiki/Main_Page --incognito");

    // Process.Start(@"C:\Users\silver\Desktop\ConsoleApplication1\x64\Debug\ConsoleApplication1.exe");
}
void KillProcess()
{
    Console.Write("Enter process PID: ");
    string? input = Console.ReadLine();

    try
    {
        if (input is null)
        {
            Console.WriteLine();
            return;
        }

        int pid = int.Parse(input);

        Process p = Process.GetProcessById(pid);

        p.Kill();
    }
    catch (Exception ex)
    {
        ShowError(ex.Message);
    }
}

Start();








