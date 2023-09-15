using ContentQualitySection.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentQualitySection.Services
{
    public class ContentQualityService : IContentQualityService
    {
        private ISpellCheckService _spellcheckService;

        public ContentQualityService()
        {
            _spellcheckService = new SpellCheckService();
        }

        public Task<double> CalculateReadTimeAsync(string content)
        {
            return Task.Run(() =>
            {
                var wordsPerMinute = 200D;
                var wordsCount = _spellcheckService.GetWords(content).Count;
                return wordsCount / wordsPerMinute;
            });
        }

        public Task<int> CheckCapitalizeWordsAsync(string content)
        {
            return Task.Run(() =>
            {
                int errorCount = 0;
                foreach (var sentence in _spellcheckService.GetSentences(content))
                {
                    var targetWord = _spellcheckService.GetWords(sentence).FirstOrDefault();
                    if (targetWord != null)
                    {
                        errorCount = _spellcheckService.IsCapitalWord(targetWord) ? errorCount : errorCount + 1;
                    }
                }
                return errorCount;
            });
        }

        public Task<int> CheckLowerWordsAsync(string content)
        {
            //return Task.Run(() =>
            //{
            //    int errorCount = 0;

            //    foreach (var sentence in _spellcheckService.GetSentences(content))
            //    {
            //        var wordsCount = _spellcheckService.GetWords(sentence).Count;
            //        if (_spellcheckService.CheckLowerWords(sentence) == (wordsCount - 1))
            //        {
            //            errorCount++;
            //        }
            //    }

            //    return errorCount;
            //});
            throw new NotImplementedException(nameof(CheckLowerWordsAsync));
        }

        public Task<int> GetComplexWordsCountAsync(string content)
        {
            return Task.Run(() =>
            {
                int count = 0;
                var complexWords = new List<string>();

                foreach (var word in _spellcheckService.GetWords(content))
                {

                    if (_spellcheckService.IsComplexWord(word) && !complexWords.Contains(word))
                    {
                        complexWords.Add(word);
                        count++;
                    }
                }
                return count;
            });
        }

        public Task<int> GetWordOccurrenceCountAsync(string content)
        {
            return Task.Run(() =>
            {
                int count = 0;

                var words = new List<string>();
                var wordsCount = _spellcheckService.GetWords(content).Count;

                foreach (var word in _spellcheckService.GetWords(content))
                {

                    if (!words.Contains(word)
                    && (_spellcheckService.GetWordCount(content, word) / (wordsCount / 100) >= 20))
                    {
                        words.Add(word);
                        count++;
                    }
                }

                return count;
            });
        }

        public Task<int> AnalyzeAsync(string content)
        {
            return Task.Run(async () =>
            {
                var score = 100;

                //Ayiriladi
                var forReadTime = 10;
                var forCapitalizeWords = 5;
                var forOccurencyCount = 10;

                //qo'shiladi
                var forComplexWords = 5;

                score = await CalculateReadTimeAsync(content) >= 5 ? score : score - forReadTime;
                score -= await CheckCapitalizeWordsAsync(content) * forCapitalizeWords;
                score -= await GetWordOccurrenceCountAsync(content) * forOccurencyCount;

                score += await GetComplexWordsCountAsync(content) * forComplexWords;

                return score;
            });



        }
    }
}
