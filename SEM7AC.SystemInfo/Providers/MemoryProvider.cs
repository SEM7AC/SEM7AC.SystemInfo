using SEM7AC.U.SystemInfo.Models;
using System.Runtime.InteropServices;

namespace SEM7AC.U.SystemInfo.Providers;

public class MemoryProvider
    {
    public static MemoryInfo Get()
        {
        var memStruct = new MEMORYSTATUSEX();
        memStruct.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));

        if (!GlobalMemoryStatusEx(ref memStruct))
            return new MemoryInfo();

        return new MemoryInfo
            {
            Total = memStruct.ullTotalPhys,
            Available = memStruct.ullAvailPhys,
            Used = memStruct.ullTotalPhys - memStruct.ullAvailPhys,
            LoadPercent = (int)memStruct.dwMemoryLoad
            };
        }

    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORYSTATUSEX
        {
        public uint dwLength;
        public uint dwMemoryLoad;
        public ulong ullTotalPhys;
        public ulong ullAvailPhys;
        public ulong ullTotalPageFile;
        public ulong ullAvailPageFile;
        public ulong ullTotalVirtual;
        public ulong ullAvailVirtual;
        public ulong ullAvailExtendedVirtual;
        }

    [DllImport("kernel32.dll")]
    public static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

    }

