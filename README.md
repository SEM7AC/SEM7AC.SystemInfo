# SEM7AC.SystemInfo

A fast, lightweight C# class library for gathering detailed
system information on Windows machines. Built for developers
who want clean, reliable access to CPU, memory, storage, and
OS data without dealing with WMI complexity.

---

## 🚀 Features

### CPU Details
- Name  
- Logical processors  
- Physical cores (approx)  
- Clock speed (MHz)

### Memory Stats
- Total  
- Available  
- Used  
- Load %

### Storage Info
- Drive totals  
- Free / used space  
- Format  
- Drive type

### OS Info
- Name  
- Version  
- Architecture  
- Boot time

### Zero Dependencies
- Pure .NET  
- Fast  
- Minimal

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

## 🔧 Installation (NuGet)
dotnet add package SEM7AC.SystemInfo

## 🧩 Usage
```csharp
var info = new SystemInfoProvider();

var cpu = info.GetCpuInfo();
var mem = info.GetMemoryInfo();
var drives = info.GetStorageInfo();
var os = info.GetOsInfo();
```
## 📁 Project Goals
- Provide a clean, modern sysinfo API for .NET developers  
- Avoid WMI complexity and legacy API pain  
- Offer predictable, structured output  
- Keep the library small, fast, and dependency‑free  
- Serve as a foundational component for future SEM7AC projects

## 🧑‍💻 Author
**SEM7AC (Christopher)**  
Developer, engineer, builder of sharp, minimal, high‑performance .NET components.

MIT — free to use, modify, and integrate.
