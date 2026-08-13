### OsProvider Documentation

Overview:
The OsProvider class retrieves high-level operating system information from Windows using .NET runtime services. It produces an OsInfo model containing OS name, version, architecture, and boot time. This provider avoids WMI and Win32 interop, relying instead on stable, cross-version .NET APIs.

Purpose:
OsProvider is responsible for gathering essential OS metadata in a clean and reliable way. Windows exposes OS version and architecture through Environment APIs, but does not provide friendly OS names. The provider maps version numbers to readable names and calculates boot time using system uptime.

Methods:
Get():
Creates and returns an OsInfo object. This method retrieves the OS version, determines architecture, maps the OS name, and calculates boot time. It is the main entry point for OS information retrieval.

GetOsName():
Maps the raw OS version numbers to friendly names. Windows does not provide readable OS names through .NET, so the provider uses version and build numbers to identify Windows 7, 8, 8.1, 10, and 11. Unknown versions fall back to a generic label.

Returned Model:
The provider returns an OsInfo object containing:
- Name: Friendly OS name such as Windows 10 or Windows 11
- Version: Raw OS version string such as "10.0.22631"
- Architecture: Operating system architecture, typically "64-bit"
- BootTime: The date and time when the system last booted

Usage Notes:
BootTime is calculated using Environment.TickCount64, which provides accurate uptime. This avoids WMI and works consistently across Windows versions. The provider focuses on essential OS metadata and does not expose edition, SKU, kernel version, or activation details.

Summary:
OsProvider uses .NET runtime services to deliver clean, high-level OS information through a simple API. It abstracts away version mapping and uptime calculation, providing a reliable way for .NET applications to retrieve operating system metadata.
