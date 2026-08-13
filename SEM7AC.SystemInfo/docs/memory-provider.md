### MemoryProvider Documentation

Overview:
The MemoryProvider class retrieves high-level physical memory information from Windows using the GlobalMemoryStatusEx API. It produces a MemoryInfo model containing total memory, available memory, used memory, and current load percentage. This provider isolates all Win32 interop logic so consumers can access memory data through a simple, predictable API.

Purpose:
MemoryProvider is responsible for gathering accurate physical memory metrics directly from the operating system. Windows exposes memory information through the MEMORYSTATUSEX structure, which must be populated and passed to GlobalMemoryStatusEx. The provider handles structure initialization, API invocation, and conversion into a clean MemoryInfo model.

Methods:
Get():
Creates and returns a MemoryInfo object. This method initializes a MEMORYSTATUSEX structure, sets its length, calls GlobalMemoryStatusEx, and maps the returned values into the MemoryInfo model. If the API call fails, the method returns an empty MemoryInfo instance.

GlobalMemoryStatusEx():
A direct P/Invoke binding to the Windows kernel32.dll function. This API fills the MEMORYSTATUSEX structure with physical memory statistics. The provider wraps this call to ensure safe usage and predictable behavior.

MEMORYSTATUSEX:
A struct that mirrors the Win32 MEMORYSTATUSEX layout. It contains fields for total physical memory, available physical memory, memory load percentage, and additional virtual memory fields. Only the physical memory fields are used by the provider.

Returned Model:
The provider returns a MemoryInfo object containing:
- Total: Total physical RAM installed, in bytes
- Available: Physical memory currently available, in bytes
- Used: Physical memory currently in use, in bytes
- LoadPercent: Percentage of physical memory in use

Usage Notes:
MemoryProvider focuses exclusively on physical memory reporting. It does not expose virtual memory, page file usage, or commit limits, even though the underlying Win32 structure contains those fields. The goal is to provide fast, accurate physical memory diagnostics suitable for monitoring and telemetry.

Summary:
MemoryProvider uses the GlobalMemoryStatusEx API to deliver accurate physical memory information through a clean, high-level API. It abstracts away all Win32 interop complexity and provides a simple, reliable way for .NET applications to retrieve memory usage data.
