### StorageProvider Documentation

Overview:
The StorageProvider class retrieves high-level storage device information from Windows using System.IO.DriveInfo. It produces a list of StorageInfo models, each representing a logical drive on the system. This provider abstracts away all DriveInfo enumeration logic and presents storage data in a clean, predictable format.

Purpose:
StorageProvider is responsible for gathering essential storage metrics such as total size, free space, used space, file system format, and drive type. Windows exposes drive information through DriveInfo, which the provider wraps and normalizes into StorageInfo objects. The goal is to provide a simple, reliable way to retrieve storage information without requiring consumers to interact with DriveInfo directly.

Methods:
Get():
Enumerates all logical drives using DriveInfo.GetDrives(). For each drive, the method constructs a StorageInfo object containing the drive name, total size, available free space, used space, file system format, and drive type. All StorageInfo objects are collected into a list and returned. If no drives are found, the method returns an empty list.

Returned Model:
Each drive is represented by a StorageInfo object containing:
- Name: Logical drive identifier such as "C:\"
- Total: Total drive capacity in bytes
- Free: Available free space in bytes
- Used: Space currently in use, in bytes
- Format: File system format such as NTFS or FAT32
- Type: Drive type such as Fixed, Removable, or Network

Usage Notes:
StorageProvider focuses exclusively on logical drive information. It does not expose hardware-level disk details such as sector size, physical media type, or NVMe/SSD/HDD classification. The provider is designed for diagnostics, telemetry, and environment reporting where logical drive usage is sufficient.

Summary:
StorageProvider uses DriveInfo to deliver clean, high-level storage information through a simple API. It abstracts away enumeration and formatting logic, providing a reliable way for .NET applications to retrieve storage device metrics.
