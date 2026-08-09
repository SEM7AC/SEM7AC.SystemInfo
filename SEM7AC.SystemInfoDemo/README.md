# SEM7AC.SystemInfo Demo

A simple demonstration project showing how to use the `SEM7AC.SystemInfo` library to retrieve CPU, memory, storage, and operating system information on Windows machines.

This demo provides a clean example of how developers can integrate the library into their own applications.

---

## 🚀 What This Demo Shows

- How to initialize the `SystemInfoProvider`
- How to retrieve CPU, memory, storage, and OS info
- How to print each property cleanly
- How to integrate the library into any .NET project

---

## 🔧 Installation

dotnet add package SEM7AC.SystemInfo

---

## 🧩 Usage Example

var info = new SystemInfoProvider();

var cpu = info.GetCpuInfo();
Console.WriteLine("=== CPU INFO ===");
Console.WriteLine($"Name: {cpu.Name}");
Console.WriteLine($"Logical Processors: {cpu.LogicalProcessors}");
Console.WriteLine($"Physical Cores: {cpu.PhysicalCores}");
Console.WriteLine($"MHz: {cpu.MHz}");

var mem = info.GetMemoryInfo();
Console.WriteLine("=== MEMORY INFO ===");
Console.WriteLine($"Total: {mem.TotalGB} GB");
Console.WriteLine($"Available: {mem.AvailableGB} GB");
Console.WriteLine($"Used: {mem.UsedGB} GB");
Console.WriteLine($"Load: {mem.LoadPercent}%");

var drives = info.GetStorageInfo();
foreach (var d in drives)
{
    Console.WriteLine("=== STORAGE INFO ===");
    Console.WriteLine($"Drive Name: {d.Name}");
    Console.WriteLine($"Total GB: {d.TotalGB}");
    Console.WriteLine($"Free GB: {d.FreeGB}");
    Console.WriteLine($"Used GB: {d.UsedGB}");
    Console.WriteLine($"Format: {d.Format}");
    Console.WriteLine($"Type: {d.Type}");
}

var os = info.GetOsInfo();
Console.WriteLine("=== OS INFO ===");
Console.WriteLine($"Name: {os.Name}");
Console.WriteLine($"Version: {os.Version}");
Console.WriteLine($"Architecture: {os.Architecture}");
Console.WriteLine($"Boot Time: {os.BootTime}");

---

## 📦 Example Output

### CPU INFO
Name: Intel(R) Core(TM) Ultra 7 265  
Logical Processors: 20  
Physical Cores: 10  
MHz: 2381  

### MEMORY INFO
Total: 15.4 GB  
Available: 5.29 GB  
Used: 10.11 GB  
Load: 65%  

### STORAGE INFO
Drive Name: C:\  
Total GB: 952.48  
Free GB: 815.21  
Used GB: 137.27  
Format: NTFS  
Type: Fixed  

Drive Name: D:\  
Total GB: 14.58  
Free GB: 13.69  
Used GB: 0.9  
Format: FAT32  
Type: Removable  

### OS INFO
Name: Windows 11  
Version: 10.0.26200.0  
Architecture: 64-bit  
Boot Time: 7/25/2026 1:48:33 PM  

---

## 📁 Project Goals

- Provide a clear example of how to use the SystemInfo library  
- Keep the demo small, simple, and easy to understand  
- Serve as a reference for future SEM7AC projects  
- Show real output from real hardware  

---

## 🧑‍💻 Author

**SEM7AC (Christopher)**  
Builder of sharp, minimal, high‑performance .NET components.
