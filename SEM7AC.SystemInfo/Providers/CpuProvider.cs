using Microsoft.Win32;
using SEM7AC.U.SystemInfo.Interop;
using SEM7AC.U.SystemInfo.Models;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;


namespace SEM7AC.U.SystemInfo.Providers;


public class CpuProvider
    {
    [SupportedOSPlatform("windows")] //<--- gets rid of warning for "Windows Only"
    public static CpuInfo Get()
        {
        return new CpuInfo
            {
            Name = GetCpuName(),
            PhysicalCores = Environment.ProcessorCount / 2, //<--- not super accurate
            RealPhysCores = GetPhysCoresFromWin32(),
            LogicalProcessors = Environment.ProcessorCount,
            MHz = GetCpuMHz()
            };

        }

    [SupportedOSPlatform("windows")]
    public static string GetCpuName()
        {
        try
            {
            using var key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0");

            return key?.GetValue("ProcessorNameString")?.ToString() ?? "Unknown CPU";
            }
        catch
            {
            return "Unknown CPU";
            }
        }

    [SupportedOSPlatform("windows")]
    public static int GetCpuMHz()
        {
        try
            {
            using var key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0");
            var value = key?.GetValue("~MHz");

            if (value == null)
                return 0;

            if (value.GetType() == typeof(int))
                return (int)value;

            return 0;
            }
        catch
            {
            return 0;
            }

        }

    [SupportedOSPlatform("windows")]
    private static int GetPhysCoresFromWin32()
        {
        uint size = 0;

        Win32Cpu.GetLogicalProcessorInformationEx(CpuRel.All, IntPtr.Zero, ref size);
        if (size == 0)
            return 0;

        IntPtr ptr = Marshal.AllocHGlobal((int)size);

        try
            {
            if (!Win32Cpu.GetLogicalProcessorInformationEx(CpuRel.All, ptr, ref size))
                return 0;

            uint offset = 0;
            int coreCount = 0;

            while (offset < size)
                {
                var header = Marshal.PtrToStructure<CpuInfoHeader>(ptr + (int)offset);

                if (header.Relationship == CpuRel.ProcessorCore)
                    coreCount++;

                offset += header.Size;
                }

            return coreCount;
            }
        finally
            {
            Marshal.FreeHGlobal(ptr);
            }
        }





    }

