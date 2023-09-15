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
            //do something
        }

        public Task<int> CheckLowerWordsAsync(string content)
        {
            throw new NotImplementedException();
        }

        public Task<int> CheckComplexWordsCountAsync(string content)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetWordOccurrenceCountAsync(string content)
        {
            throw new NotImplementedException();
        }

        public Task<int> AnalyzeAsync(string content)
        {
            throw new NotImplementedException();
        }
    }
}
