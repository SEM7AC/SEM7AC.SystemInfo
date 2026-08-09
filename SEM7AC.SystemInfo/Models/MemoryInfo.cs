namespace SEM7AC.U.SystemInfo.Models;

public class MemoryInfo
    {
    public ulong Total { get; set; }
    public ulong Available { get; set; }
    public ulong Used { get; set; }
    public int LoadPercent { get; set; }
    }

