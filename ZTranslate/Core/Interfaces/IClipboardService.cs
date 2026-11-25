namespace ZTranslate.Core.Interfaces;

public interface IClipboardService
{
    Task<string?> GetSelectedTextAsync();
}
