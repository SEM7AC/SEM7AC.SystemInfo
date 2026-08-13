### Win32 CPU Interop Documentation

Overview:
SEM7AC.SystemInfo includes low-level Win32 bindings for retrieving CPU topology information. These bindings map directly to the Windows API function GetLogicalProcessorInformationEx. Windows exposes CPU cores, NUMA nodes, cache levels, and processor groups through this API. The complexity comes from the Win32 API design, not the library.

Purpose:
Windows does not provide a simple managed API for CPU topology. To retrieve physical core count, logical processor mapping, cache hierarchy, NUMA layout, and processor group distribution, the library must call GetLogicalProcessorInformationEx. This file provides the required P/Invoke definitions so higher-level code can parse CPU topology safely.

API Binding:
The Win32Cpu class defines the P/Invoke signature for GetLogicalProcessorInformationEx. The function returns a variable-length buffer containing one or more SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX structures. The library handles buffer sizing, repeated calls, marshaling, and structure interpretation. Consumers never interact with this API directly.

Relationship Types:
The CpuRel enum defines the relationship type requested from the API. Options include ProcessorCore, NumaNode, Cache, ProcessorPackage, Group, and All. Each relationship type determines what kind of CPU information is returned.

Structure Definitions:
The file defines several structs that map exactly to Win32 memory layouts. These include:
- CpuInfoHeader: Contains relationship type and structure size.
- AffinityMask: Represents a processor mask inside a processor group.
- ProcRel: Describes a physical core and its associated logical processors.
- NumaRel: Describes a NUMA node and its processor mask.
- CacheRel: Describes cache level, size, associativity, and type.
- GroupRel: Describes processor group capacity and active processors.
- CpuInfoEx: The union structure returned by the API. Only one union field is valid depending on the relationship type.

Important Notes:
These structs must remain exactly as defined. Any change to ordering, padding, or field types will break interop. The Win32 API uses variable-length structures, so the library must manually walk the buffer. Consumers of the NuGet package never interact with these structs directly. Higher-level CPU models are built on top of this interop layer.

How the Library Uses This:
The CPU provider calls GetLogicalProcessorInformationEx, parses the returned buffer, extracts core count, logical processor count, cache sizes, and processor group information, and exposes clean C# models such as CpuInfo. This isolates all Win32 complexity inside the interop layer.

NuGet Summary:
SEM7AC.SystemInfo includes full Win32 bindings for CPU topology retrieval using GetLogicalProcessorInformationEx. These bindings expose core, cache, NUMA, and processor group information through safe, high-level C# models. All Win32 interop complexity is fully encapsulated inside the library.
