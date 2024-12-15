using System.Reflection;
using System.Runtime.Loader;

#region AppDomain

//AppDomain domain  = AppDomain.CurrentDomain;

//Console.WriteLine($"{domain.FriendlyName}\t{domain.BaseDirectory}");

//foreach (Assembly assembly in domain.GetAssemblies())
//    Console.WriteLine($"{assembly.GetName().Name}\t{assembly.GetName().Version}");

#endregion

#region Static loading
//using MathLib;

//AppDomain domain = AppDomain.CurrentDomain;

//Console.WriteLine($"{domain.FriendlyName}\t{domain.BaseDirectory}");

//foreach (Assembly assembly in domain.GetAssemblies())
//    Console.WriteLine($"{assembly.GetName().Name}\t{assembly.GetName().Version}");

//Calculator calc = new Calculator();
//Console.WriteLine(calc.Sum(3, 4));
//Console.WriteLine(Calculator.Factorial(5));

#endregion

#region Dynamic loading

AppDomain domain = AppDomain.CurrentDomain;

Console.WriteLine("\n====== Before loading:");
RenderAssemblies(domain);

AssemblyLoadContext ctx = new AssemblyLoadContext("lib_ctx", true);
ctx.Unloading += ctx => Console.WriteLine("\n====== UNLOADING =======");

Assembly assembly = ctx.LoadFromAssemblyPath(Path.Combine(Directory.GetCurrentDirectory(), "MathLib.dll"));

Console.WriteLine("\n====== After loading:");
RenderAssemblies(domain);

Type? type = assembly.GetType("MathLib.Calculator");

// ---- static call
MethodInfo? staticMethod = type?.GetMethod("Factorial");
int? factorial = (int?)staticMethod?.Invoke(assembly, [5]);
Console.WriteLine($"Factorial result = {factorial}");

// ---- non-static call
MethodInfo? nonStaticMethod = type?.GetMethod("Sum");
object? calc = Activator.CreateInstance(type);
int? sum = (int?)nonStaticMethod?.Invoke(calc, [3, 4]);
Console.WriteLine($"Sum result = {sum}");

ctx.Unload();
GC.Collect();

Console.WriteLine("\n====== After unloading:");
RenderAssemblies(domain);

void RenderAssemblies(AppDomain domain)
{
    foreach (Assembly assembly in domain.GetAssemblies())
        Console.WriteLine($"{assembly.GetName().Name}\t{assembly.GetName().Version}");
}

#endregion
