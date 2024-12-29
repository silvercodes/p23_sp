// ==== TPL (Task Parallel Library) ====

#region Task
// -- Создание задачи --

//Task t1 = new Task(() => Console.WriteLine("Vasia_1"));
//t1.Start();

//Task t2 = Task.Factory.StartNew(() => Console.WriteLine("Vasia_2"));

//Task t3 = Task.Run(() => Console.WriteLine("Vasia_3"));

////
////
////
////

//t1.Wait();
//t2.Wait();
//t3.Wait();




// --- Синхронное выполнение Task ---
//Task t = new Task(() =>
//{
//    Console.WriteLine("start");
//    Thread.Sleep(1000);
//    Console.WriteLine("end");
//});

//t.Start();              // async call
//// t.RunSynchronously();   // sync call

//Console.WriteLine("END MAIN");
//Console.ReadLine();





// --- Task state ---
//Task t = new Task(() =>
//{
//    Console.WriteLine("start");
//    Thread.Sleep(1000);
//    Console.WriteLine("end");
//});
//t.Start();

//Console.WriteLine(t.Id);
//Console.WriteLine(t.Status);
//Console.WriteLine(t.IsCompleted);

//t.Wait();





// --- Вложенные задачи ---

//Console.WriteLine("Main started");

//Task t1 = new Task(() =>
//{
//    Console.WriteLine("t1 started");

//    Task t2 = new Task(() =>
//    {
//        Console.WriteLine("t2 started");
//        Thread.Sleep(3000);
//        Console.WriteLine("t2 finished");
//    }, TaskCreationOptions.AttachedToParent);

//    t2.Start();

//    Console.WriteLine("t1 finished");
//});

//t1.Start();
//t1.Wait();

//Console.WriteLine("Main finished");

//Console.ReadLine();





// --- Массив задач ---

//long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

//List<Task> tasks = new List<Task>()
//{
//    new Task(() =>
//    {
//        Thread.Sleep(1000);
//        Console.WriteLine("Task 1000 finished");
//    }),
//    new Task(() =>
//    {
//        Thread.Sleep(1200);
//        Console.WriteLine("Task 1200 finished");
//    }),
//    new Task(() =>
//    {
//        Thread.Sleep(2000);
//        Console.WriteLine("Task 2000 finished");
//    }),
//};

//tasks.ForEach(t => t.Start());

////Task.WaitAll(tasks.ToArray());
//Task.WaitAny(tasks.ToArray());

//Console.WriteLine($"REsult time = {DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - start}");





// --- Возврат результата ---

//Task<int> t = new Task<int>(() =>
//{
//    Thread.Sleep(1000);
//    return 10;
//});

//t.Start();
////
////
//int res = t.Result;             // BLOCKING
//Console.WriteLine($"Result = {res}");





//int Sum(int a, int b) => a + b;

//int a = 4;
//int b = 5;

//Task<int> t = new Task<int>(() => Sum(a, b));
//t.Start();
////
////
//Console.WriteLine(t.Result);        // BLOCKING





//Task<Thread> t = new Task<Thread>(() =>
//{
//    Thread thread = new Thread(() => Console.WriteLine("test"));

//    return thread;
//});

//t.Start();
////
////
//Thread thread = t.Result;       // BLOCKING
//thread.Start();
//thread.Join();                  // BLOCKING





// --- Цепочка тасков ---

//Task<int> t = new Task<int>(() =>
//{
//    Task<int> t1 = new Task<int>(() => 5);
//    t1.Start();
//    //
//    int r = t1.Result;

//    Task<int> t2 = new Task<int>(() => r * r);
//    t2.Start();
//    //
//    return t2.Result;
//});

//t.Start();
////
////
//Console.WriteLine(t.Result);





//Task t1 = new Task(() => Console.WriteLine("start task"));
//Task t2 = t1.ContinueWith(t =>
//{
//    Console.WriteLine(t.Id);
//    Console.WriteLine(Task.CurrentId);
//});

//t1.Start();
////
////
//t2.Wait();





//Task t1 = new Task(() => Console.WriteLine("start task"));
//Task chain = t1
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id));

//t1.Start();
////
////
//chain.Wait();






//int a = 3;
//int b = 5;
//int Sum(int a, int b) => a + b;

//Task<int> t1 = new Task<int>(() => Sum(a, b));
//Task t2 = t1.ContinueWith(t =>
//{
//    Thread.Sleep(200);
//    Console.ForegroundColor = ConsoleColor.Green;
//    Console.WriteLine(t.Result);
//    Console.ResetColor();
//});

//t1.Start();
////
////
//t2.Wait();
#endregion

#region Parallel

// ---- Invoke()
//void Render()
//{
//    Thread.Sleep(2000);
//    Console.WriteLine("Test print");
//}
//void Sum(int a, int b) => Console.WriteLine($"Result = {a + b}");

//// sync call
//Parallel.Invoke(
//    Render,
//    () => Sum(4, 5),
//    () => Console.WriteLine("Test lambda")
//);
//Console.WriteLine("Main");

// async call
//Task t = Task.Run(() => Parallel.Invoke(
//    Render,
//    () => Sum(4, 5),
//    () => Console.WriteLine("Test lambda")
//));

//Console.WriteLine("Main");
//t.Wait();


// ---- For()
//long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

//ThreadPool.SetMinThreads(20, 4);

//Parallel.For(0, 20, i =>
//{
//    Console.WriteLine($"task_{Task.CurrentId}: {i}");
//    Thread.Sleep(1000);
//});

//Console.WriteLine($"REsult time = {DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - start}");




// ---- Foreach()
//long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
//ThreadPool.SetMinThreads(11, 4);
//List<int> nums = new() {4, 6, 7, 8, 2, 3, 4, 1, 2, 2, 0 };

//Parallel.ForEach(nums, n =>
//{
//    Thread.Sleep(1000);
//    Console.WriteLine(n);
//});

//Console.WriteLine($"REsult time = {DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - start}");




// ---- Мягкое прерывание ----
//CancellationTokenSource cts = new CancellationTokenSource();
//CancellationToken token = cts.Token;

//Task t = new Task(() => { 
//    for (int i = 0; i < 10; i++)
//    {
//        if (token.IsCancellationRequested)
//        {
//            Console.WriteLine("Cancellation requested");
//            return;
//        }
//        Console.WriteLine(i);
//        Thread.Sleep(1000);
//    }
//}, token);

//t.Start();
//Console.ReadLine();
//cts.Cancel();

//Thread.Sleep(1000);
//Console.WriteLine(t.Status);


// ---- Жёсткое прерывание ----
//CancellationTokenSource cts = new CancellationTokenSource();
//CancellationToken token = cts.Token;

//Task t = new Task(() => {

//    //Task.Run(() => 
//    //{
//    //    Thread.Sleep(2000);
//    //    throw new ArgumentException("ha-ha");
//    //}).Wait();

//    for (int i = 0; i < 10; i++)
//    {
//        if (token.IsCancellationRequested)
//        {
//            // token.ThrowIfCancellationRequested();
//            throw new ArgumentException("ho-ho");
//        }
//        Console.WriteLine(i);
//        Thread.Sleep(1000);
//    }
//}, token);


//try
//{
//    t.Start();

//    Console.ReadLine();
//    cts.Cancel();

//    t.Wait();
//}
//catch (AggregateException aex)
//{
//    Console.WriteLine($"count = {aex.InnerExceptions.Count}");

//    foreach (Exception ex in aex.InnerExceptions)
//    {
//        if (ex is TaskCanceledException)
//        {
//            Console.WriteLine("Task cancelled....");
//            Console.WriteLine(ex.Message);
//        }
//        else
//        {
//            Console.WriteLine($"ERROR: {ex.Message}");
//        }
//    }
//}

//Thread.Sleep(1000);
//Console.WriteLine(t.Status);




// ---- Отмена цикла ----
//CancellationTokenSource cts = new CancellationTokenSource();
//CancellationToken token = cts.Token;

//List<int> nums = new() { 4, 6, 7, 8, 2, 3, 4, 1, 2, 2, 0 };

//_ = Task.Run(() =>
//{
//	Thread.Sleep(1000);
//	cts.Cancel();
//});

//try
//{
//	Parallel.ForEach(nums, new ParallelOptions() { CancellationToken = token }, n =>
//	{
//		Thread.Sleep(1000);
//		Console.WriteLine(n);
//	});
//}
//catch (Exception)
//{
//    Console.WriteLine("CANCELLED...");
//}

#endregion
