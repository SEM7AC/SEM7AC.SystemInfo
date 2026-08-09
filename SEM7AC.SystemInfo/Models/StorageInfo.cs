namespace SEM7AC.U.SystemInfo.Models;

public class StorageInfo
    {
    public string? Name { get; set; }
    public long Total { get; set; }
    public long Free { get; set; }
    public long Used { get; set; }
    public string? Format { get; set; }
    public string? Type { get; set; }
    }

