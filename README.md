SEM7AC.SystemInfo
A fast, lightweight C# class library for gathering detailed system information on Windows machines. 
Built for developers who want clean, reliable access to CPU, memory, storage, and OS data without 
digging through WMI hell or platform‑specific APIs.

🚀 Features
CPU Details  
Name, logical processors, physical cores, clock speed (MHz)

Memory Stats  
Total, available, used, load percentage

Storage Information  
Drive totals, free/used space, format, type

Operating System Info  
Name, version, architecture, boot time

Zero external dependencies  
Pure .NET. Fast. Clean. Minimal.

📦 Example Output
Code
=== CPU INFO ===
Name: Intel(R) Core(TM) Ultra 7 265
Logical Processors: 20
Physical Cores (approx): 10
MHz: 2381

=== MEMORY INFO ===
Total: 15.4 GB
Available: 5.29 GB
Used: 10.11 GB
Load: 65%

=== STORAGE INFO ===
Drive Name: C:\
Total GB:   952.48
Free GB:    815.21
Used GB:    137.27
Format:     NTFS
Type:       Fixed

Drive Name: D:\
Total GB:   14.58
Free GB:    13.69
Used GB:    0.9
Format:     FAT32
Type:       Removable

=== OS INFO ===
Name:        Windows 11
Version:     10.0.26200.0
Architecture:64-bit
Boot Time:   7/25/2026 1:48:33 PM
🔧 Installation (NuGet)
Code
dotnet add package SEM7AC.SystemInfo
(Package name placeholder until you publish — this README is ready for it.)

🧩 Usage
csharp
var info = new SystemInfoProvider();

var cpu = info.GetCpuInfo();
var mem = info.GetMemoryInfo();
var drives = info.GetStorageInfo();
var os = info.GetOsInfo();

📁 Project Goals
Provide a clean, modern sysinfo API for .NET developers

Avoid WMI complexity and legacy API pain

Offer predictable, structured output

Keep the library small, fast, and dependency‑free

Serve as a foundational component for future SEM7AC projects

🧑‍💻 Author
SEM7AC (Christopher)  
Developer, engineer, builder of sharp, minimal, high‑performance .NET components.

📜 License
MIT — free to use, modify, and integrate.
