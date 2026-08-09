using SEM7AC.U.SystemInfo.Models;

namespace SEM7AC.U.SystemInfo.Providers;

public class StorageProvider
    {
    public static List<StorageInfo> Get()
        {
        DriveInfo[] drives = DriveInfo.GetDrives();
        List<StorageInfo> driveList = new();

        foreach (DriveInfo hd in drives)
            {
            var bigHD = new StorageInfo
                {
                Name = hd.Name,
                Total = hd.TotalSize,
                Free = hd.AvailableFreeSpace,
                Used = hd.TotalSize - hd.TotalFreeSpace,
                Format = hd.DriveFormat,
                Type = hd.DriveType.ToString(),

                };
            driveList.Add(bigHD);
            }
        return driveList;
        }
    }

