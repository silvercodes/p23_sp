
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






bool done = false;
object locker = new object();

void Run()
{
    lock (locker)
    {
        if (!done)
        {
            Console.Write('*');   // <<1 <<2  
            done = true;
            Console.WriteLine("DONE");
        }
    }
}

new Thread(Run).Start();
Run();

