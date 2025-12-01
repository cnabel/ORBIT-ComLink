# ORBIT ComLink

ORBIT ComLink is a standalone radio client for DCS World. It provides Voice over IP (VoIP) communication with radio simulation features.

This project is a fork from DCS-SimpleRadioStandalone.

## Building from Source

### Prerequisites

- Windows 10/11
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 with:
  - .NET Desktop development workload
  - Desktop development with C++ workload (for ComLink-Lua-Wrapper)
- NuGet CLI

### Quick Build

```bash
# Restore NuGet packages
nuget restore

# Build solution (Release x64)
msbuild /p:Configuration=Release /p:Platform=x64
```

### Full Publish

```powershell
# Publish without code signing
./publish.ps1 -NoSign

# Publish and create zip archive
./publish.ps1 -NoSign -Zip
```

For detailed build instructions and development workflows, see [COPILOT.md](COPILOT.md).
