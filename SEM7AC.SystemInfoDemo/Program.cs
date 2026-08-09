using SEM7AC.U.SystemInfo;


namespace SEM7AC.U.SystemInfoDemo;

public class Program
    {
    static void Main(string[] args)
        {
       
        var sys = SysInfo.Get();

        Console.WriteLine("=== CPU INFO ===");
        Console.WriteLine($"Name: {sys.Cpu.Name}");
        Console.WriteLine($"Logical Processors: {sys.Cpu.LogicalProcessors}");
        Console.WriteLine($"Physical Cores (approx): {sys.Cpu.PhysicalCores}");
        Console.WriteLine($"MHz: {sys.Cpu.MHz}");
        Console.WriteLine();

        Console.WriteLine("=== MEMORY INFO ===");
        Console.WriteLine($"Total: {sys.Memory.Total / 1024d / 1024d / 1024d:0.##} GB");
        Console.WriteLine($"Available: {sys.Memory.Available / 1024d / 1024d / 1024d:0.##} GB");
        Console.WriteLine($"Used: {sys.Memory.Used / 1024d / 1024d / 1024d:0.##} GB");
        Console.WriteLine($"Load: {sys.Memory.LoadPercent}%");
        Console.WriteLine();

        Console.WriteLine("=== STORAGE INFO ===");
        foreach (var d in sys.Storage)
            {
            Console.WriteLine($"Drive Name: {d.Name}");
            Console.WriteLine($"Total GB:   {d.Total / 1024d / 1024d / 1024d:0.##}");
            Console.WriteLine($"Free GB:    {d.Free / 1024d / 1024d / 1024d:0.##}");
            Console.WriteLine($"Used GB:    {(d.Total - d.Free) / 1024d / 1024d / 1024d:0.##}");
            Console.WriteLine($"Format:     {d.Format}");
            Console.WriteLine($"Type:       {d.Type}");
            Console.WriteLine();
            }
        Console.WriteLine();

        Console.WriteLine("=== OS INFO ===");
        Console.WriteLine($"Name:        {sys.Os.Name}");
        Console.WriteLine($"Version:     {sys.Os.Version}");
        Console.WriteLine($"Architecture:{sys.Os.Architecture}");
        Console.WriteLine($"Boot Time:   {sys.Os.BootTime}");
        Console.WriteLine();

        Console.ReadLine();
        }
    }
