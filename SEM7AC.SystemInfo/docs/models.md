### SystemInfo Models Documentation

Overview:
The SEM7AC.SystemInfo library exposes a set of high-level models that represent CPU, memory, storage, and operating system information. These models provide a clean, consumer-friendly view of system diagnostics without requiring any interaction with Win32 APIs or low-level platform details. All values are normalized, safe, and suitable for telemetry, dashboards, and environment reporting.

---

CpuInfo:
Represents high-level CPU metadata gathered from Windows APIs and topology parsing. Fields include:
- Name: The CPU's marketing name from the Windows registry.
- PhysicalCores: An estimated physical core count based on logical processor data.
- RealPhysCores: The actual physical core count retrieved using GetLogicalProcessorInformationEx.
- LogicalProcessors: The number of logical processors available to the OS.
- MHz: The reported base clock speed in megahertz.

CpuInfo provides a simple snapshot of CPU characteristics and abstracts away all Win32 interop complexity.

---

MemoryInfo:
Represents physical memory usage retrieved from GlobalMemoryStatusEx. Fields include:
- Total: Total physical RAM installed, in bytes.
- Available: Physical memory currently available, in bytes.
- Used: Physical memory currently in use, in bytes.
- LoadPercent: Percentage of physical memory in use.

MemoryInfo offers a minimal, accurate view of system memory pressure suitable for diagnostics and monitoring.

---

StorageInfo:
Represents logical drive information retrieved from System.IO.DriveInfo. Fields include:
- Name: Drive identifier such as "C:\".
- Total: Total drive capacity in bytes.
- Free: Available free space in bytes.
- Used: Space currently in use, in bytes.
- Format: File system format such as NTFS or FAT32.
- Type: Drive type such as Fixed, Removable, or Network.

StorageInfo provides a straightforward view of storage usage without exposing hardware-level disk details.

---

OsInfo:
Represents operating system metadata retrieved from Windows runtime services. Fields include:
- Name: Friendly OS name such as Windows 10 or Windows 11.
- Version: Raw OS version string such as "10.0.22631".
- Architecture: Operating system architecture, typically 64-bit.
- BootTime: The date and time when the system last booted.

OsInfo offers a clean snapshot of OS characteristics suitable for environment reporting.

---

SystemInfoResult:
Represents the unified output of the SEM7AC.SystemInfo library. Fields include:
- Cpu: A CpuInfo object containing CPU metadata.
- Memory: A MemoryInfo object containing memory usage details.
- Storage: A list of StorageInfo objects representing all logical drives.
- Os: An OsInfo object containing operating system metadata.

SystemInfoResult provides a complete system snapshot in a single structure, ideal for diagnostics, telemetry, and monitoring dashboards.

---

Summary:
These models form the high-level API surface of SEM7AC.SystemInfo. They abstract away all Win32 complexity and present a simple, predictable set of structures suitable for any .NET application requiring system diagnostics or environment reporting.
