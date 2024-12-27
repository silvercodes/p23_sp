
// === Инструменты (конструкции) сихронизации ===

// 1. Простые методы блокировки (Thread.Sleep(...), Thread.Join(...), Task.Wait(...))

// 2. Контроль критической секции кода (lock, Monitor<20ns>, Mutex<1000ns>, SpinLock, Semaphore<1000ns>, SemaphoreSlim ....)

// 3. Конструкции сигнализации (Monitor.Pulse(), Monitor.PulseAll(), Monitor.Wait(), AutoResetEvent, ManualResetEvent, CountDownResetEvent ....)

// 4. Неблокирующие инструменты (Thread.MemoryBarrier(), Thread.VolitileRead(), Interlocked ....)


// === Причины разблокировки ===
// 1. Выполнение условий блокировки
// 2. Таймаут
// 3. Thread.Interrupt()
// 4. Thread.Abort()


//Thread t = Thread.CurrentThread;
//bool isBlocked = (t.ThreadState & ThreadState.WaitSleepJoin) != 0;      // :-)
//Console.WriteLine(isBlocked);


#region lock / Monitor

//new Thread(ThreadUnsafe.Run).Start();
//ThreadUnsafe.Run();

//class ThreadUnsafe
//{
//    static int a = 4;
//    static int b = 5;
//    static object locker = new object();

//    public static void Run()
//    {
//        int c = 0;

//        // FIFO for other threads
//        lock (locker)
//        {
//            if (b != 0)
//                c = a / b;

//            b = 0;
//        }
//    }
//}





//new Thread(ThreadUnsafe.Run).Start();
//ThreadUnsafe.Run();

//class ThreadUnsafe
//{
//    static int a = 4;
//    static int b = 5;
//    static object locker = new object();

//    public static void Run()
//    {
//        int c = 0;
//        bool flag = false;

//        try
//        {
//            // FIFO
//            Monitor.Enter(locker, ref flag);        // Попытка взятия блокировки

//            if (b != 0)
//                c = a / b;

//            b = 0;
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"{ex.Message}");
//        }
//        finally
//        {
//            if (flag)
//                Monitor.Exit(locker);               // Освобождение блокировки
//        }
//    }
//}







//object locker = new Object();
//int val = 0;

//void Run()
//{
//    bool flag = false;

//	try
//	{
//		flag = Monitor.TryEnter(locker, 3000);   // Попытки взятия блокировки (втечение 500мс)

//        if (flag)
//		{
//			for (int i = 0; i < 10; i++)
//			{
//                Console.WriteLine($"{Thread.CurrentThread.Name}: {val++}");
//				Thread.Sleep(200);
//            }
//		}
//		else
//			Console.WriteLine($"{Thread.CurrentThread.Name} is looser");
//	}
//	catch (Exception ex) 
//	{
//        Console.WriteLine($"{ex.Message}");
//    }
//	finally
//	{
//		if (flag)
//			Monitor.Exit(locker);               // Освобождение блокировки
//	}
//}

//for (int i = 0; i < 5; ++i)
//{
//	Thread t = new Thread(Run)
//	{
//		Name = $"thread_{i}"
//	};
//	t.Start();
//}




// --- Любой объект ссылочного типа, который доступен всем потокам может выступать в качесте объекта блокировки

//class Container
//{
//    private List<string> Emails { get; set; } = new List<string>();

//    public void Run()
//    {
//        //
//        //
//        lock (Emails)
//        {
//            Emails.Add("random@mail.com");
//        }
//        //
//        //
//    }
//}

#endregion

#region Deadlock

//object locker1 = new Object();
//object locker2 = new Object();

//new Thread(() =>
//{
//    lock(locker1)
//    {
//        Thread.Sleep(1000);

//        lock (locker2)
//        {
//            //
//        }
//    }
//}).Start();

//lock(locker2)
//{
//    Thread.Sleep(1000);

//    lock(locker1)
//    {
//        //
//    }
//}

#endregion

#region Mutex

//int count = 0;
//Mutex mutex = new Mutex();

//void UseResource()
//{
//    if (mutex.WaitOne(500))             // Попытка захвата мьютекса
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name} take the mutex");

//        Thread.Sleep(200);
//        count++;

//        Console.WriteLine($"{Thread.CurrentThread.Name} done the work");

//        Console.WriteLine($"{Thread.CurrentThread.Name} release mutex");

//        mutex.ReleaseMutex();          // Освобождение мьютекса
//    }
//    else
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name} is looser");
//    }
//}

//void StartThreads()
//{
//    for (int i = 0; i < 5; ++i)
//    {
//        Thread t = new Thread(UseResource)
//        {
//            Name = $"thread_{i}",
//        };

//        t.Start();
//    }
//}

//StartThreads();

#endregion

#region Semaphore (НЕэксклюзивная блокировка)

//Semaphore semaphore = new Semaphore(0, 3);  // (<кол-во свободных мест>, <максимальная ёмкость>)
//int executionTime = 0;
//object locker = new object();

//void Run(int id)
//{
//    Console.WriteLine($"Thread {id} started");

//    semaphore.WaitOne();                                    // попытка взять блокировку (пройти за семафор)

//    Console.WriteLine($"Thread {id} passed semaphore");

//    int time;
//    lock (locker)
//    {
//        executionTime += 200;
//        time = executionTime;
//    }

//    Thread.Sleep(time + 2000);

//    Console.WriteLine($"Thread {id} relesed semaphore");

//    semaphore.Release();                                    // освобождает 1 место
//}

//for (int i = 1; i <= 5; ++i)
//{
//    int x = i;
//    Thread t = new Thread(() => Run(x));
//    t.Start();
//}

//Thread.Sleep(3000);
//semaphore.Release(3);                                       // // освобождает 3 места

#endregion

#region Signaling

//object locker = new Object();

//void First()
//{
//	try
//	{
//		Monitor.Enter(locker);

//		for (int i = 1; i <= 10; i += 2)
//		{
//			Thread.Sleep(200);
//            Console.Write($"{i} ");
//			Monitor.Pulse(locker);
//			Monitor.Wait(locker);
//        }
//	}
//	finally
//	{
//		Monitor.Exit(locker);
//	}
//}

//void Second()
//{
//    try
//    {
//        Monitor.Enter(locker);

//        for (int i = 0; i <= 10; i += 2)
//        {
//            Thread.Sleep(200);
//            Console.Write($"{i} ");
//            Monitor.Pulse(locker);
//            Monitor.Wait(locker);
//        }
//    }
//    finally
//    {
//        Monitor.Exit(locker);
//    }
//}

//Thread t1 =  new Thread(First);
//Thread t2 = new Thread(Second);

//t2.Start();
//Thread.Sleep(3000);
//t1.Start();


//AutoResetEvent are = new AutoResetEvent(false);
//EventWaitHandle mre = new ManualResetEvent(false);



//SimpleWaitHandle.Run();
//static class SimpleWaitHandle
//{
//    static EventWaitHandle wh = new AutoResetEvent(false);

//    public static void Run()
//    {
//        new Thread(Work).Start();
//        Thread.Sleep(3000);
//        wh.Set();
//    }

//    public static void Work()
//    {
//        Console.WriteLine("Work(): waiting...");
//        wh.WaitOne();
//        Console.WriteLine("Working...");
//    }
//}

#endregion










