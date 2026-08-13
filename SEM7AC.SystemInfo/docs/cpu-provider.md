### CpuProvider Documentation

Overview:
The CpuProvider class retrieves high-level CPU information from Windows using a combination of registry queries, .NET runtime values, and Win32 topology parsing. It produces a CpuInfo model containing CPU name, core counts, logical processor count, and clock speed. This provider isolates all low-level logic so consumers can access CPU data through a simple, predictable API.

Purpose:
CpuProvider is responsible for gathering CPU metadata from multiple sources. Windows does not expose a single unified API for CPU information, so the provider combines registry access, Environment values, and GetLogicalProcessorInformationEx to produce accurate results. The goal is to provide a clean, high-level snapshot of CPU characteristics without requiring consumers to interact with Win32 APIs.

Methods:
Get():
Creates and returns a CpuInfo object. This method calls all other provider methods to populate CPU name, physical core estimates, real physical core count, logical processor count, and MHz. It is the main entry point for CPU information retrieval.

GetCpuName():
Reads the ProcessorNameString value from the Windows registry. This provides the CPU’s marketing name. If the registry key is unavailable, the method returns "Unknown CPU". This approach avoids WMI and works reliably across Windows versions.

GetCpuMHz():
Reads the "~MHz" registry value to retrieve the CPU’s base clock speed. This value represents the nominal frequency, not boost clocks. If the registry value is missing or invalid, the method returns 0.

GetPhysCoresFromWin32():
Uses GetLogicalProcessorInformationEx to retrieve detailed CPU topology. The method allocates a buffer, walks through variable-length structures, and counts entries where the relationship type is ProcessorCore. This produces the most accurate physical core count available on Windows. All Win32 complexity is contained inside this method.

Returned Model:
The provider returns a CpuInfo object containing:
- Name: CPU marketing name
- PhysicalCores: Estimated physical core count
- RealPhysCores: Accurate physical core count from Win32 topology
- LogicalProcessors: Number of logical processors available to the OS
- MHz: Base clock speed in megahertz

Usage Notes:
PhysicalCores is a simple estimate based on logical processor count and may differ from RealPhysCores on hybrid or SMT-enabled CPUs. RealPhysCores should be used when accuracy is required. The provider is Windows-only and marked with SupportedOSPlatform attributes to avoid cross-platform warnings.

Summary:
CpuProvider combines registry access, runtime values, and Win32 topology parsing to deliver accurate CPU information through a clean, high-level API. It abstracts away all low-level details and provides a simple, reliable way for .NET applications to retrieve CPU metadata.
