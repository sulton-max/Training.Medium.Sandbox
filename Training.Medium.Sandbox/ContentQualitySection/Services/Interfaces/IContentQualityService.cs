namespace ContentQualitySection.Services.Interfaces;

public interface IContentQualityService
{
    Task<decimal> CalculateReadTimeAsync(string content);
    Task<int> CheckCapitalizeWordsAsync(string content);
    Task<int> CheckLowerWordsAsync(string content);
    Task<int> CheckComplexWordsCountAsync(string content);
    Task<int> GetWordOccurrenceCountAsync(string content);
    Task<int> AnalyzeAsync(string content);
}