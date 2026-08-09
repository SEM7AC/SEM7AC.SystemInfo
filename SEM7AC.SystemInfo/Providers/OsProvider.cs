using SEM7AC.U.SystemInfo.Models;

namespace SEM7AC.U.SystemInfo.Providers;

public class OsProvider
    {

    public static OsInfo Get()
        {
        var os = Environment.OSVersion;
        var arch = Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit";

        return new OsInfo
            {
            Name = GetOsName(),
            Version = os.Version.ToString(),
            Architecture = arch,
            BootTime = DateTime.Now - TimeSpan.FromMilliseconds(Environment.TickCount64)
            };
        }

    private static string GetOsName()
        {
        // .NET doesn't give friendly names, so we map the common ones
        var v = Environment.OSVersion.Version;

        return v.Major switch
            {
                10 when v.Build >= 22000 => "Windows 11",
                10 => "Windows 10",
                6 when v.Minor == 3 => "Windows 8.1",
                6 when v.Minor == 2 => "Windows 8",
                6 when v.Minor == 1 => "Windows 7",
                _ => "Windows (Unknown Version)"
                };
        }
    }


