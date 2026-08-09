namespace SEM7AC.U.SystemInfo.Models;

public class SystemInfoResult
    {
    public CpuInfo? Cpu { get; set; }
    public MemoryInfo? Memory { get; set; }
    public List<StorageInfo>? Storage { get; set; }
    public OsInfo? Os { get; set; }
    }

