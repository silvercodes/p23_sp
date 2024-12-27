// ==== TPL (Task Parallel Library) ====


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

Console.WriteLine("Main started");

Task t1 = new Task(() =>
{
    Console.WriteLine("t1 started");

    Task t2 = new Task(() =>
    {
        Console.WriteLine("t2 started");
        Thread.Sleep(3000);
        Console.WriteLine("t2 finished");
    }, TaskCreationOptions.AttachedToParent);

    t2.Start();

    Console.WriteLine("t1 finished");
});

t1.Start();
t1.Wait();

Console.WriteLine("Main finished");
















