using SEM7AC.U.SystemInfo.Models;
using SEM7AC.U.SystemInfo.Providers;
using System.Runtime.Versioning;

namespace SEM7AC.U.SystemInfo
    {
    public static class SysInfo
        
        {
    [SupportedOSPlatform("windows")]
        public static SystemInfoResult Get()
            {
            return new SystemInfoResult
                {
                Cpu = CpuProvider.Get(),
                Memory = MemoryProvider.Get(),
                Storage = StorageProvider.Get(),
                Os = OsProvider.Get()
                };
            }
        }
    }
    
