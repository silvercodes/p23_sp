
// === Инструменты (конструкции) сихронизации ===

// 1. Простые методы блокировки (Thread.Sleep(...), Thread.Join(...), Task.Wait(...))

// 2. Контроль критической секции кода (lock, Monitor<20ns>, Mutex<1000ns>, SpinLock, Semaphore<1000ns>, SemaphoreSlim ....)

// 3. Конструкции сигнализации (Monitor.Pulse(), Monitor.PulseAll(), .Wait(), AutoResetEvent, ManualResetEvent, CountDownResetEvent ....)

// 4. Неблокирующие инструменты (Thread.MemoryBarrier(), Thread.VolitileRead(), Interlocked ....)


// === Причины разблокировки ===
// 1. Выполнение условий блокировки
// 2. Таймаут
// 3. Thread.Interrupt()
// 4. Thread.Abort()


Thread t = Thread.CurrentThread;
bool isBlocked = (t.ThreadState & ThreadState.WaitSleepJoin) != 0;      // :-)
Console.WriteLine(isBlocked);


new Thread(ThreadUnsafe.Run).Start();
ThreadUnsafe.Run();

class ThreadUnsafe
{
    static int a = 4;
    static int b = 5;
    static object locker = new object();

    public static void Run()
    {
        int c = 0;

        // FIFO for other threads
        lock (locker)
        {
            if (b != 0)
                c = a / b;

            b = 0; 
        }
    }
}








