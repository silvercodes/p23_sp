
#region Intro

//Thread t = new Thread(Show);
//t.Start();

//Console.Write(t.IsAlive);

//for (int i = 0; i < 100; i++)
//    Console.Write('0');

//void Show()
//{
//    for (int i = 0; i < 100; i++)
//        Console.Write('+');
//}




//void Run()
//{
//    for (int i = 0; i < 10; i++)
//        Console.Write('0');
//}

//Run();
//new Thread(Run).Start();




//bool done = false;

//void Run()
//{
//    if (! done)
//    {
//        Console.Write('*');   // <<1 <<2  
//        done = true;
//        Console.WriteLine("DONE");
//    }
//}

//new Thread(Run).Start();
////new Thread(Run).Start();
////new Thread(Run).Start();
////new Thread(Run).Start();
////new Thread(Run).Start();
////new Thread(Run).Start();
////new Thread(Run).Start();
////new Thread(Run).Start();
//Run();






//bool done = false;
//object locker = new object();

//void Run()
//{
//    lock (locker)
//    {
//        if (!done)
//        {
//            Console.Write('*');   // <<1 <<2  
//            done = true;
//            Console.WriteLine("DONE");
//        }
//    }
//}

//new Thread(Run).Start();
//Run();




// ==== Join/Sleep ====

//void Run()
//{
//    for (int i = 0;  i < 1000; ++i)
//    {
//        Console.Write('*');
//        Thread.Sleep(1);    // Блокируем текущий поток на ~1мс
//    }

//    Console.WriteLine();
//}

//Thread t = new Thread(Run);
//t.Start();
//t.Join(500);                  // Блокируем текущий поток на 500мс или ждём поток t

//Console.WriteLine("Main finished");


#endregion

#region Create / Run Thread

// thread scheduler

// time slicing

// ==== Простые способы ====

//void Run()
//{
//    Console.WriteLine("hello");
//}

//// Thread t = new Thread(new ThreadStart(Run));
//// >>> EQUALS <<<
//Thread t = new Thread(Run);
//t.Start();
//Run();


//Thread t = new Thread(() => Console.WriteLine("hello"));


//string email = "vasia@mail.com";
//Thread t = new Thread(() => Console.WriteLine(email));


//void Calc(int a, int b) => Console.WriteLine(a + b);

//int a = 5;
//int b = 6;
//Thread t = new Thread(() => Calc(a, b));


//void Show(object? obj)
//{
//    Console.WriteLine(obj.ToString());
//}

//Thread t = new Thread(Show);
//t.Start("Vasia");



//void RenderColoredMessage(string message, ConsoleColor color)
//{
//    Console.ForegroundColor = color;
//    Console.WriteLine(message);
//    Console.ResetColor();
//}

//string message = "Hello Vasia";
//ConsoleColor color = ConsoleColor.Red;
//Thread t = new Thread(() => RenderColoredMessage(message, color));
//t.Start();



// === "Подводный камень" с лямбдой ===

//for (int i = 0; i < 10; ++i)
//    new Thread(() => Console.WriteLine(i)).Start();
// Решение
//for (int i = 0; i < 10; ++i)
//{
//    int temp = i;
//    new Thread(() => Console.WriteLine(temp)).Start();
//}



//int i;
//List<Thread> threads = new List<Thread>();
//for (i = 0; i < 10; ++i)
//    threads.Add(new Thread(() => Console.WriteLine(i)));

//threads.ForEach(t => t.Start());





//void Run()
//{
//    Console.WriteLine($"Message from {Thread.CurrentThread.Name}");
//}

//Thread.CurrentThread.Name = "main";
//Thread t = new Thread(Run)
//{
//    Name = "worker",
//};

//t.Start();
//Run();

//Console.ReadLine();






// === Backgroud / Foreground threads ===

//Thread t = new Thread(() => Console.ReadLine());

//if (args.Length > 0)
//    t.IsBackground = true;

//t.Start();

#endregion

#region try / catch

//void Run()
//{
//    throw new Exception("Test exception");
//}

//try
//{
//    new Thread(Run).Start();
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"ERROR: {ex.Message}");
//}





//void Run()
//{
//	try
//	{
//        throw new Exception("Test exception");
//    }
//	catch (Exception ex)
//	{
//        Console.WriteLine($"ERROR: {ex.Message}");
//    }
//}

//new Thread(Run).Start();

#endregion
