using ContentQualitySection.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentQualitySection.Services
{
    public class SpellCheckService : ISpellCheckService
    {
        public int GetComplexWordsCount(string content, int length)
        {
            if (length < 0)
            {
                return 0;
            }

            return GetWords(content).Count(word => word.Length >= length);
        }

        public IList<string> GetSentences(string content)
        {
            return content.Split('.', '!', '?')
                .Where(sentence => !string.IsNullOrWhiteSpace(sentence)).ToList();
        }

        public IList<string> GetSplitWords(string content)
        {
            return content.Split(' ', '.', ',', '?', '!');
        }

        public int GetWordCount(string content, string wordForSearch)
        {
            return GetWords(content).Count(word => word.Equals(wordForSearch, StringComparison.OrdinalIgnoreCase));
        }

        public IList<string> GetWords(string content)
        {
            return GetSplitWords(content)
                .Where(word => !string.IsNullOrWhiteSpace(word)).ToList();
        }

        public bool IsCapitalWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return false;

            string formattedWord = string.Concat(
                word.Substring(0, 1).ToUpper(),
                word.Substring(1).ToLower());

            return word == formattedWord;
        }

        public bool IsComplexWord(string word)
        {
            //Words list berilsa o'sha list ichida borligi tekshiriladi
            return string.IsNullOrWhiteSpace(word) ? false : word.Length > 20;
        }

        public bool IsLowerWord(string word)
        {
            return word == word.ToLower();
        }

        public int CheckLowerWords(string content)
        {
            var words = GetWords(content);
            var lowerWordsCount = words.Count(word => IsLowerWord(word));
            return lowerWordsCount;
        }

    }
}
