using Microsoft.Extensions.DependencyInjection;
using ZTranslate.Core.Interfaces;
using ZTranslate.Services;
using ZTranslate.ViewModels;

namespace ZTranslate.Core;

/// <summary>
/// DI registration for all ZTranslate services.
/// Universe Architecture: Registry pattern — auto-register, no hard-coding in App.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddXTranslateServices(this IServiceCollection services)
    {
        // --- Core Services (Singletons — app-lifetime) ---
        services.AddSingleton<ISettingsService, SettingsService>();
        services.AddSingleton<IHotkeyService, HotkeyService>();
        services.AddSingleton<IClipboardService, ClipboardService>();
        services.AddSingleton<TextSelectionMonitor>();
        services.AddSingleton<HistoryService>();

        // --- Translation Engine Registry ---
        services.AddSingleton<TranslationEngineRegistry>(sp =>
        {
            var registry = new TranslationEngineRegistry();
            registry.Register(new GoogleTranslateEngine());
            registry.Register(new MyMemoryTranslateEngine());
            registry.Register(new LingvaTranslateEngine());
            registry.Register(new LocalLlmTranslateEngine());
            return registry;
        });
        services.AddSingleton<TranslationService>();

        // --- OCR ---
        services.AddSingleton<IOcrEngine, WindowsOcrEngine>();
        services.AddSingleton<ScreenCaptureService>();

        // --- Text-to-Speech ---
        services.AddSingleton<ITtsService, WindowsTtsService>();

        // --- ViewModels ---
        services.AddSingleton<MainViewModel>();
        services.AddTransient<PopupViewModel>();

        // --- Orchestrator ---
        services.AddSingleton<AppOrchestrator>();

        return services;
    }
}
