using System.Runtime.InteropServices;

namespace SEM7AC.U.SystemInfo.Interop;

// Low-level Win32 CPU topology bindings.
// These structs and enums map directly to the Windows API for 
// GetLogicalProcessorInformationEx. 
// Required for retrieving core, cache, and processor group details.
// The complexity comes from the Win32 API design, not this library.



public static class Win32Cpu
    {
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GetLogicalProcessorInformationEx(
        CpuRel relationshipType,
        IntPtr buffer,
        ref uint returnLength
    );
    }

[StructLayout(LayoutKind.Sequential)]
public struct CpuInfoHeader
    {
    public CpuRel Relationship;
    public uint Size;
    }


// Short enum for relationship types
public enum CpuRel : uint
    {
    ProcessorCore = 0,
    NumaNode = 1,
    Cache = 2,
    ProcessorPackage = 3,
    Group = 4,
    All = 0xFFFF
    }

// Cache type enum
public enum CacheType
    {
    Unified,
    Instruction,
    Data,
    Trace
    }

// GROUP_AFFINITY (short name: AffinityMask)
[StructLayout(LayoutKind.Sequential)]
public struct AffinityMask
    {
    public ulong Mask;
    public ushort Group;
    public ushort Reserved1;
    public ushort Reserved2;
    public ushort Reserved3;
    }

// PROCESSOR_RELATIONSHIP (short name: ProcRel)
[StructLayout(LayoutKind.Sequential)]
public struct ProcRel
    {
    public byte Flags;
    public byte EfficiencyClass;
    public byte Reserved1;
    public byte Reserved2;
    public byte Reserved3;
    public byte Reserved4;
    public int GroupCount;
    // Followed by GROUP_AFFINITY array (variable length)
    }

// NUMA_NODE_RELATIONSHIP (short name: NumaRel)
[StructLayout(LayoutKind.Sequential)]
public struct NumaRel
    {
    public int NodeNumber;
    public AffinityMask GroupMask;
    }

// CACHE_RELATIONSHIP (short name: CacheRel)
[StructLayout(LayoutKind.Sequential)]
public struct CacheRel
    {
    public byte Level;
    public byte Associativity;
    public ushort LineSize;
    public int CacheSize;
    public CacheType Type;
    public AffinityMask GroupMask;
    }

// PROCESSOR_GROUP_INFO (short name: GroupRel)
[StructLayout(LayoutKind.Sequential)]
public unsafe struct GroupRel
    {
    public byte MaximumProcessorCount;
    public byte ActiveProcessorCount;
    public fixed byte ActiveProcessorMask[1]; // variable length
    }

// SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX (short name: CpuInfoEx)
[StructLayout(LayoutKind.Sequential)]
public struct CpuInfoEx
    {
    public CpuRel Relationship;
    public int Size;

    // Union — all fields present, only one is valid depending on Relationship
    public ProcRel Processor;
    public NumaRel NumaNode;
    public CacheRel Cache;
    public GroupRel Group;
    }



