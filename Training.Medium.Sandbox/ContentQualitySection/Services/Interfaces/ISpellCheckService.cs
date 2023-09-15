using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentQualitySection.Services.Interfaces
{
    public interface ISpellCheckService
    {
        /// <summary>
        /// Gets the words from the content
        /// </summary>
        /// <param name="content">The content to split to words</param>
        /// <returns>Words list</returns>
        IList<string> GetWords(string content);

        /// <summary>
        /// Gets the splitted word from the content
        /// </summary>
        /// <param name="content">The content to split to words</param>
        /// <returns></returns>
        IList<string> GetSplitWords(string content);

        /// <summary>
        /// Gets the sentences from the content
        /// </summary>
        /// <param name="content">The content to split to sentences</param>
        /// <returns>Sentences list</returns>
        IList<string> GetSentences(string content);

        /// <summary>
        /// Gets the given word occurrence from the content
        /// </summary>
        /// <param name="content">The content to count words from</param>
        /// <param name="word">The word to count the occurrence</param>
        /// <returns>The word occurrence count</returns>
        int GetWordCount(string content, string word);

        /// <summary>
        /// Checks if given word starts with capital letter
        /// </summary>
        /// <param name="word">The word to check</param>
        /// <returns>True if given word starts with capital letter, otherwise false</returns>
        bool IsCapitalWord(string word);

        /// <summary>
        /// Checks if given word is in lower
        /// </summary>
        /// <param name="word"></param>
        /// <returns>True if given word is in lower, otherwise false</returns>
        bool IsLowerWord(string word);

        /// <summary>
        /// Gets the given complex word occurrence from the content
        /// </summary>
        /// <param name="word"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        int GetComplexWordsCount(string content, int length);

        /// <summary>
        /// Checks if given word is complex
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        bool IsComplexWord(string word);

        /// <summary>
        /// Barcha so'zlarni lowercase ligiga tekshiradi
        /// </summary>
        /// <param name="content"></param>
        /// <returns>lower words count</returns>
        int CheckLowerWords(string content);
    }
}
