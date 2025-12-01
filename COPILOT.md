# ORBIT-ComLink Development Guide

This document provides essential information for agents and developers working on the ORBIT-ComLink repository. ORBIT-ComLink is a fork of DCS-SimpleRadioStandalone (SRS), a radio communication application for DCS World flight simulator.

## Repository Overview

ORBIT-ComLink enables realistic radio communication for DCS World multiplayer sessions. It synchronizes with the in-game radios and provides networked voice communication between players.

### Key Features

- Voice over IP (VoIP) communication for DCS World
- Radio simulation with frequency, modulation, and encryption support
- Client-server architecture for multiplayer
- DCS integration via Lua scripts and C++ DLL
- Cross-platform server (Windows/Linux)

## Project Structure

```
ORBIT-ComLink/
├── Common/                 # Shared library (networking, models, helpers)
├── ComLink-Client/         # Main WPF radio client application
├── ComLink-CommonTests/    # Unit tests (MSTest)
├── ComLink-ExternalAudio/  # External audio integration (TTS, recordings)
├── Server/                 # WPF Server GUI application
├── ServerCommandLine/      # Cross-platform command-line server
├── SharedAudio/            # Audio processing library
├── AutoUpdater/            # Client auto-update functionality
├── Installer/              # Windows installer application
├── ComLink-Lua-Wrapper/    # C++ DLL for DCS Lua integration
├── Scripts/                # Lua scripts for DCS integration
│   ├── DCS-SRS/            # Main SRS scripts and UI
│   └── Hooks/              # DCS hook scripts
└── docs/                   # Screenshots and images
```

### Main Components

| Project | Type | Description |
|---------|------|-------------|
| `ComLink-Client` | WPF App (.NET 9.0) | Radio client with overlay UI |
| `Server` | WPF App (.NET 9.0) | Server with GUI |
| `ServerCommandLine` | Console App (.NET 9.0) | Headless server for Windows/Linux |
| `Common` | Library (.NET 9.0) | Shared code: networking, models, settings |
| `SharedAudio` | Library (.NET 9.0) | Audio encoding/decoding, effects |
| `ComLink-ExternalAudio` | Console App (.NET 9.0) | External audio player (TTS, files) |
| `ComLink-Lua-Wrapper` | C++ DLL (x64) | Native DCS integration |

## Build Instructions

### Prerequisites

- Windows 10/11 (required for client/server GUI)
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 with:
  - .NET Desktop development workload
  - Desktop development with C++ workload (for SRS-Lua-Wrapper)
- NuGet CLI

### Building with Visual Studio

1. Open `ORBIT-ComLink.sln`
2. Select `Release` | `x64` configuration
3. Build solution (Ctrl+Shift+B)

### Building with Command Line

```bash
# Restore NuGet packages
nuget restore

# Build solution (Release x64)
msbuild /p:Configuration=Release /p:Platform=x64

# Or use dotnet for individual projects
dotnet build ./Common/Common.csproj -c Release
dotnet build ./ComLink-Client/ComLink-Client.csproj -c Release
```

### Publishing (Full Release Build)

```powershell
# Full publish with signing (requires certificate)
./publish.ps1

# Publish without code signing
./publish.ps1 -NoSign

# Publish and create zip archive
./publish.ps1 -NoSign -Zip
```

The publish script outputs to `./install-build/`:
- `Client/` - Main client application
- `Server/` - Server GUI
- `ServerCommandLine-Windows/` - Windows server (self-contained)
- `ServerCommandLine-Linux/` - Linux server (self-contained)
- `ExternalAudio/` - External audio tool
- `Scripts/` - DCS integration scripts

## Testing

### Running Tests

Tests use MSTest framework and target `net9.0-windows`.

```bash
# Run tests with dotnet
dotnet test ./ComLink-CommonTests/ComLink-CommonTests.csproj -c Release

# Run tests with VSTest (CI method)
VSTest.Console ComLink-CommonTests\bin\Release\net9.0-windows\ComLink-CommonTests.dll
```

### Test Structure

```
ComLink-CommonTests/
├── Helpers/
│   └── ConversionHelpersTests.cs    # Byte/short conversion tests
└── Network/
    └── UDPVoicePacketTests.cs       # Voice packet encoding/decoding tests
```

### Writing Tests

Tests follow MSTest conventions:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ORBIT.ComLink.Common.Tests.YourNamespace;

[TestClass]
public class YourTests
{
    [TestMethod]
    public void YourTestMethod()
    {
        // Arrange
        // Act  
        // Assert
        Assert.AreEqual(expected, actual);
    }
}
```

## Linting and Formatting

### Lua Formatting (StyLua)

Lua scripts are formatted with [StyLua](https://github.com/JohnnyMorganz/StyLua).

Configuration: `.stylua.toml`
```toml
syntax = "Lua51"
column_width = 120
indent_type = "Spaces"
indent_width = 4
```

Ignored files: `.styluaignore`

```bash
# Format Lua files
stylua .

# Check without modifying
stylua --check .
```

### C# Formatting

Currently no automated C# formatter configured (TODO in workflow). Follow existing code style.

## Configuration Files

| File | Purpose |
|------|---------|
| `global.json` | .NET SDK version (9.0.0) |
| `.stylua.toml` | StyLua Lua formatter config |
| `.styluaignore` | Files to ignore for Lua formatting |
| `ComLink-Client/NLog.config` | Client logging configuration |
| `Server/NLog.config` | Server logging configuration |

## Key Dependencies

### .NET Packages

- **NAudio** (2.2.1) - Audio capture and playback
- **MahApps.Metro** (2.4.11) - WPF UI framework
- **SharpDX.DirectInput** (4.2.0) - Joystick/controller input
- **NLog** (6.0.6) - Logging
- **Caliburn.Micro.Core** (5.0.258) - MVVM framework
- **SharpConfig** (3.2.9.1) - Configuration file parsing
- **Concentus** - Opus audio codec
- **WebRtcVadSharp** - Voice activity detection

### External Dependencies

- **speexdsp.dll** - Audio DSP library (bundled with client)
- **srs.dll** - Native DCS integration (built from SRS-Lua-Wrapper)

## CI/CD Pipeline

### GitHub Actions Workflows

#### Build (`build.yml`)
- Runs on: `windows-2025`
- Triggers: Push, Pull Request
- Steps:
  1. Checkout
  2. Setup MSBuild, NuGet
  3. Restore packages
  4. Build (Release x64)
  5. Run VSTest

#### Formatter (`formatter.yml`)
- Runs on: `ubuntu-latest`
- Triggers: PR merge
- Formats Lua files with StyLua

## Development Workflows

### Adding a New Feature

1. Create feature branch from `main`
2. Make changes following existing patterns
3. Add tests in `DCS-SR-CommonTests` if applicable
4. Run `dotnet test` to verify
5. Build with `msbuild /p:Configuration=Release /p:Platform=x64`
6. Submit PR

### Modifying Radio Presets

Radio presets are JSON files in `ComLink-Client/RadioModels/`.
See `ComLink-Client/RadioModels/HOWTO.md` for DSP effects documentation.

### Modifying DCS Integration

1. Lua scripts: `Scripts/DCS-SRS/`
2. Native wrapper: `ComLink-Lua-Wrapper/`
3. Rebuild C++ project: `msbuild .\ComLink-Lua-Wrapper\ComLink-Lua-Wrapper.vcxproj /p:Configuration=Release /p:Platform=x64`

## Network Protocol

### Voice Packet Format

Voice is transmitted via UDP with a binary protocol defined in `Common/Models/UDPVoicePacket.cs`:

```
[2 bytes] Total packet length
[2 bytes] Audio part length
[2 bytes] Frequencies part length
[n bytes] Audio data (Opus encoded)
[n bytes] Frequency/modulation/encryption data
[4 bytes] Unit ID
[8 bytes] Packet number
[1 byte]  Retransmission count
[22 bytes] Transmission GUID
[22 bytes] Client GUID
```

### Default Ports

| Port | Protocol | Purpose |
|------|----------|---------|
| 5002 | TCP | Client-server control |
| 5002 | UDP | Voice communication |

## Troubleshooting

### Common Build Issues

1. **NuGet restore fails**: Run `nuget restore` manually
2. **SRS-Lua-Wrapper fails**: Ensure C++ workload is installed in VS
3. **Tests fail to run**: Ensure `net9.0-windows` SDK is installed

### Logging

Logs are configured via NLog. Check:
- Client: `%APPDATA%\ORBIT-ComLink\clientlog.txt`
- Server: Application directory `serverlog.txt`

## External Resources

- [DCS World](https://www.digitalcombatsimulator.com/)
- [Original SRS Repository](https://github.com/ciribob/DCS-SimpleRadioStandalone)
- [NAudio Documentation](https://github.com/naudio/NAudio)
- [NetCoreServer](https://github.com/chronoxor/NetCoreServer) (included in Common/NetCoreServer)
