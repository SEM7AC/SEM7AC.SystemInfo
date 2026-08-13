# SEM7AC SystemInfo Repository

This repository contains the `SEM7AC.SystemInfo` library and its accompanying demo application. The goal of this repo is to provide a clean, modern, dependency‑free way to retrieve system information on Windows machines using .NET.

The library is lightweight, fast, and designed for developers who want predictable, structured system data without dealing with WMI complexity or legacy APIs.

[![NuGet Version](https://img.shields.io/nuget/v/SEM7AC.SystemInfo.svg?style=for-the-badge)](https://www.nuget.org/packages/SEM7AC.SystemInfo/)
![NuGet Downloads](https://img.shields.io/nuget/dt/SEM7AC.SystemInfo.svg?style=for-the-badge)
![GitHub Release](https://img.shields.io/github/v/release/SEM7AC/SEM7AC.SystemInfo?style=for-the-badge)
![License: MIT](https://img.shields.io/badge/License-MIT-green.svg?style=for-the-badge)





---

## 📦 Projects in This Repository

### **1. SEM7AC.SystemInfo (Library)**
A standalone .NET library that exposes CPU, memory, storage, and OS information through a simple, modern API.

**Features:**
- CPU info (name, cores, logical processors, MHz)
- Memory info (total, available, used, load)
- Storage info (drives, free/used space, format, type)
- OS info (name, version, architecture, boot time)
- No external dependencies  
- Clean, structured models  
- Fast and lightweight  

### **2. SEM7AC.SystemInfo.Demo (Console App)**
A small console application demonstrating how to use the library.  
Shows how to retrieve and print system information in a readable format.

---

## 🚀 Getting Started

Clone the repository:

git clone https://github.com/SEM7AC/SystemInfo.git

Navigate into the repo:

cd SystemInfo

Build the solution:

dotnet build

Run the demo:

dotnet run --project SEM7AC.SystemInfo.Demo

---

## 🔧 Installing the Library (NuGet)

dotnet add package SEM7AC.SystemInfo

*(Package name placeholder until published.)*

---

## 🧩 Library Usage Example

var info = new SystemInfoProvider();

var cpu = info.GetCpuInfo();
var mem = info.GetMemoryInfo();
var drives = info.GetStorageInfo();
var os = info.GetOsInfo();

---

## 📁 Repository Goals

- Provide a modern, developer‑friendly system info API  
- Avoid WMI and legacy Windows APIs  
- Keep the library small, fast, and dependency‑free  
- Offer a clean demo for quick onboarding  
- Serve as a foundation for future SEM7AC tooling  

---

## 🧑‍💻 Author

**SEM7AC (Christopher)**  
Builder of sharp, minimal, high‑performance .NET components.

