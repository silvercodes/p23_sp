
// async await

// 1. Типы возврата асинхронных методов
// Task
// Task<T>
// void         :-(
// ValueTask<T>
// IAsyncEnumerator<T>
// IAsyncEnumerable<T>
// ... ?

// 2. async => внутри можно использовать await

// 3. ....Async



// СИНХРОННЫЙ КОД!!!
//void Method()
//{
//    Console.WriteLine("Before call");

//    Task t1 = Task.Run(()  => Thread.Sleep(1000));
//    t1.Wait();
//    Console.WriteLine("t1 OK");

//    Task t2 = Task.Run(() => Thread.Sleep(2000));
//    t2.Wait();
//    Console.WriteLine("t2 OK");

//}

//Method();
//Console.WriteLine("Main");
//Console.ReadLine();


//// АСИНХРОННЫЙ КОД!!!
//async void MethodAsync()
//{
//    Console.WriteLine("Before call");                   // в текущем потоке

//    Task t1 = Task.Run(() => Thread.Sleep(1000));       // в текущем потоке
//    await t1;                                           // "прерывание метотда" до момента завершения таска(асинхронной операции)
//    Console.WriteLine("t1 OK");                         // в текущем потоке

//    Task t2 = Task.Run(() => Thread.Sleep(2000));       // в текущем потоке
//    await t2;                                           // "прерывание метотда" до момента завершения таска(асинхронной операции)
//    Console.WriteLine("t2 OK");                         // в текущем потоке
//}

//MethodAsync();
//Console.WriteLine("Main");
//Console.ReadLine();




//async Task RenderAsync()
//{
//    await Task.Run(() => Thread.Sleep(1000));
//    // >>> EQUALS <<<
//    await Task.Delay(1000);

//    Console.Out.WriteLine("Test");
//}

//Task t = RenderAsync();
////
////
////
//await t;






//async Task<int> SquareAsync(int n)
//{
//    await Task.Delay(1000);
//    return n * n;
//}

//async Task OperationAsync(int n)
//{
//    int result = await SquareAsync(n);

//    await Console.Out.WriteLineAsync(result.ToString());
//}

//_ = OperationAsync(4);

//Console.ReadLine();





//async Task RenderAsync(string message)
//{
//    await Task.Delay(1000);
//    await Console.Out.WriteLineAsync(message);
//}

//Task t1 = RenderAsync("Vasia");
//Task t2 = RenderAsync("Petya");
//Task t3 = RenderAsync("Dima");

//// Task.WaitAll(t1, t2, t3);           // BLOCKING
//// await Task.WhenAll(t1, t2, t3);

//// Task.WaitAny(t1, t2, t3);               // BLOCKING
//await Task.WhenAny(t1, t2, t3);





//async Task<int> SquareAsync(int n)
//{
//    await Task.Delay(1000);
//    return n * n;
//}

//Task<int> t1 = SquareAsync(5);
//Task<int> t2 = SquareAsync(6);
//Task<int> t3 = SquareAsync(11);

//int[] results = await Task.WhenAll(t1, t2, t3);
//foreach (int item in results)
//    Console.WriteLine(item);






//async Task<bool> ValidateEmailAsync(string email)
//{
//    await Task.Delay(1000);

//    if (email.Length < 5)
//        throw new ArgumentException("Invalid email...");

//    return true;
//}

//try
//{
//    await ValidateEmailAsync("vasia@mail.com");
//    await ValidateEmailAsync("v@i");
//    Console.WriteLine('*');
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.GetType());
//    Console.WriteLine(ex.Message);
//}




CancellationTokenSource cts = new CancellationTokenSource();
CancellationToken token = cts.Token;

List<string> planets = new List<string>()
{
    "Mercury",
    "Venus",
    "Earth",
    "Mars",
};

Task t = Parallel.ForEachAsync(planets, async (p, token) =>
{
    await Console.Out.WriteLineAsync(p);
});
