# SEM7AC.SystemInfo Demo

A simple demonstration project showing how to use the `SEM7AC.SystemInfo` library to retrieve CPU, memory, storage, and operating system information on Windows machines.

This demo provides a clean example of how developers can integrate the library into their own applications using the unified `SysInfo.Get()` API.

---

## 🚀 What This Demo Shows

- How to call the unified `SysInfo.Get()` method
- How to retrieve CPU, memory, storage, and OS info
- How to print each property cleanly
- How to integrate the library into any .NET project

---

## 🔧 Installation

dotnet add package SEM7AC.SystemInfo

---

## 🧩 Usage Example

```csharp
using SEM7AC.U.SystemInfo;

var sys = SysInfo.Get();

// CPU
Console.WriteLine("=== CPU INFO ===");
Console.WriteLine($"Name: {sys.Cpu.Name}");
Console.WriteLine($"Logical Processors: {sys.Cpu.LogicalProcessors}");
Console.WriteLine($"Physical Cores (approx): {sys.Cpu.PhysicalCores}");
Console.WriteLine($"MHz: {sys.Cpu.MHz}");
Console.WriteLine();

// Memory
Console.WriteLine("=== MEMORY INFO ===");
Console.WriteLine($"Total: {sys.Memory.Total / 1024d / 1024d / 1024d:0.##} GB");
Console.WriteLine($"Available: {sys.Memory.Available / 1024d / 1024d / 1024d:0.##} GB");
Console.WriteLine($"Used: {sys.Memory.Used / 1024d / 1024d / 1024d:0.##} GB");
Console.WriteLine($"Load: {sys.Memory.LoadPercent}%");
Console.WriteLine();

// Storage
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

// OS
Console.WriteLine("=== OS INFO ===");
Console.WriteLine($"Name:        {sys.Os.Name}");
Console.WriteLine($"Version:     {sys.Os.Version}");
Console.WriteLine($"Architecture:{sys.Os.Architecture}");
Console.WriteLine($"Boot Time:   {sys.Os.BootTime}");
```