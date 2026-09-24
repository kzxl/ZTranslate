using ZTranslate.Models;

namespace ZTranslate.Core.Interfaces;

public interface ISettingsService
{
    AppSettings Settings { get; }
    void Load();
    void Save();
}
