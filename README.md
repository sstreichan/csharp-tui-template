# C# TUI Template

A template for building Terminal User Interface (TUI) applications using **Spectre.Console** with **Native AOT** compilation support.

## Features

- ✨ **Spectre.Console** - Modern and beautiful terminal UI library
- 🚀 **Native AOT** - Fast startup and low memory footprint
- 🔄 **GitHub Actions** - Automated builds for Linux, Windows, and macOS
- 📦 **Automated Releases** - Changelog generation and binary publishing

## Prerequisites

- [.NET 8 SDK](https://dotnet.net/download/dotnet/8.0) or later
- For Native AOT compilation:
  - **Linux**: `clang`, `zlib1g-dev`
  - **Windows**: Visual Studio 2022 with C++ Desktop Development workload
  - **macOS**: Xcode Command Line Tools

## Getting Started

### Clone and Run

```bash
git clone https://github.com/sstreichan/csharp-tui-template.git
cd csharp-tui-template
dotnet run
```

### Build Native AOT Binary

```bash
# Linux
dotnet publish -c Release -r linux-x64

# Windows
dotnet publish -c Release -r win-x64

# macOS
dotnet publish -c Release -r osx-x64
```

The compiled binary will be in `./bin/Release/net8.0/{runtime}/publish/`

## Project Structure

```
├── CSharpTuiTemplate.csproj   # Project configuration with Native AOT enabled
├── Program.cs                  # Main application entry point
├── .github/
│   └── workflows/
│       ├── build-publish.yml   # CI/CD for builds
│       └── release.yml         # Release automation
└── README.md
```

## GitHub Actions

### Build and Publish Workflow

Automatically triggered on:
- Push to `main` branch
- Pull requests to `main`
- Manual workflow dispatch

Builds Native AOT binaries for Linux, Windows, and macOS.

### Release Workflow

Triggered when you create a version tag (e.g., `v1.0.0`):

```bash
git tag v1.0.0
git push origin v1.0.0
```

This will:
1. Generate a changelog from commits
2. Build Native AOT binaries for all platforms
3. Create a GitHub release with binaries attached

## Customization

### Update Application Name

1. Rename `CSharpTuiTemplate.csproj` to your project name
2. Update `<AssemblyName>` in the `.csproj` file
3. Update namespace in `Program.cs`
4. Update workflows to match new binary names

### Add Dependencies

```bash
dotnet add package PackageName
```

**Note**: Not all packages support Native AOT. Check compatibility before adding.

## Spectre.Console Resources

- [Documentation](https://spectreconsole.net/)
- [Examples](https://github.com/spectreconsole/spectre.console/tree/main/examples)
- [API Reference](https://spectreconsole.net/api/)

## Native AOT Considerations

- Reflection is limited - use source generators where possible
- Some NuGet packages may not be compatible
- Binary size is typically larger than regular builds
- Startup time is significantly faster
- No .NET runtime installation required on target machines

## License

MIT License - feel free to use this template for your projects!
