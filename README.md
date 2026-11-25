# ZTranslate — Instant On-Screen Translator & Subtitle HUD for Windows

[![Platform](https://img.shields.io/badge/Platform-Windows%2010%2F11%20x64-0078D6?style=flat-square&logo=windows)](https://dotnet.microsoft.com/)
[![Stack](https://img.shields.io/badge/.NET-8.0%20WPF-512BD4?style=flat-square&logo=dotnet)](ZTranslate/ZTranslate.csproj)
[![Offline AI](https://img.shields.io/badge/Offline%20LLM-Ollama%20%7C%20LM%20Studio-2ea44f?style=flat-square)](#key-features)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue?style=flat-square)](LICENSE)
[![GitHub stars](https://img.shields.io/github/stars/kzxl/ZTranslate?style=social)](https://github.com/kzxl/ZTranslate/stargazers)

> **Lightweight Windows desktop translation suite (.NET 8 WPF) with instant cursor popup, screen capture OCR, real-time subtitle HUD, text-to-speech, and offline Local LLM (Ollama / LM Studio) translation.**

---

## Key Features

- **Instant Cursor Popup (`Ctrl + Q`)**: Highlight text in any Windows app and press a hotkey to view a sleek, auto-dismissing dark glassmorphism popup right at your cursor.
- **Detailed Translation Window (`Ctrl + Enter`)**: Full editor for long passages, language swapping, history lookup, and TTS playback.
- **Real-Time Subtitle HUD**: Always-on-top transparent subtitle overlay (`SubtitleHudWindow`) for live reading, videos, or meetings.
- **Offline Local LLM Engine**: Native OpenAI-compatible Local LLM translation provider (`LocalLlmTranslateEngine`) supporting **Ollama** and **LM Studio** with zero cloud data leakage.
- **Multi-Engine Registry**: Switch seamlessly between **Google Translate**, **Lingva**, **MyMemory**, and **Local LLM** backends.
- **Screen Capture OCR**: Built-in region capture overlay backed by Windows OCR (`WindowsOcrEngine`) to translate text inside images, PDFs, or games.
- **Smart Auto-Language Flip & TTS**: Detects native language to automatically swap source/target directions and reads translations aloud via `WindowsTtsService`.

---

## Default Hotkeys

| Shortcut | Action |
| :--- | :--- |
| `Ctrl + Q` | Show Floating Popup Translation at cursor |
| `Ctrl + Enter` | Open Detailed Main Translation Window |
| `Esc` | Dismiss active translation popup / window |

---

## Quick Start & Build

### Prerequisites
- Windows 10 (1809+) or Windows 11 (x64)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (to build from source) or [.NET 8 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0) (for Lite build)
- Optional: [Ollama](https://ollama.com/) or [LM Studio](https://lmstudio.ai/) for offline Local LLM translation

### Build & Publish

```powershell
git clone https://github.com/kzxl/ZTranslate.git
cd ZTranslate

# Run unit tests
dotnet test

# Publish lightweight single-file executable (requires .NET 8 Desktop Runtime)
.\publish.ps1 -Mode Lite

# Or publish self-contained single-file executable (zero runtime prerequisites)
.\publish.ps1 -Mode Full
```

Published executables are generated under `publish/lite/` and `publish/full/`.

---

## Architecture

Built with clean MVVM separation and `Microsoft.Extensions.DependencyInjection` in C# WPF:
- **Global Input & Capture**: Win32 keyboard hooks (`SetWindowsHookEx`) and selection/clipboard orchestration (`TextSelectionMonitor`, `ClipboardService`).
- **Pluggable Engines**: `ITranslationEngine` implementations registered via `TranslationEngineRegistry` (`GoogleTranslateEngine`, `LingvaTranslateEngine`, `MyMemoryTranslateEngine`, `LocalLlmTranslateEngine`).
- **Windows Native Services**: `WindowsOcrEngine` for region OCR and `WindowsTtsService` for speech synthesis.

---

## License

Licensed under the [MIT License](LICENSE). Part of the [`ZeroUniverse`](https://github.com/kzxl/ZeroUniverse) ecosystem.

---

If **ZTranslate** speeds up your daily reading or workflow, consider giving it a ⭐ on GitHub!
