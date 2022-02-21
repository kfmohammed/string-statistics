using System;
using System.Linq;

namespace TechTest
{
    /// <summary>
    /// Extracts statistics from the supplied string.
    /// </summary>
    public class StringStatsProcessor : IStringStatsProcessor
    {
        /// <summary>
        /// Extracts statistics from the supplied string.
        /// </summary>
        /// <param name="subject">Must not be null.</param>
        /// <returns>A model containing statistics for the supplied string.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the supplied input is null.</exception>
        public StringStatsModel Run(string subject)
        {
            if (subject == null) throw new ArgumentNullException(nameof(subject), "Value cannot be null.");

            var stringStats = new StringStatsModel();

            var delimiters = new[] { ' ', '\r', '\n' };
            var words = subject.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).OrderByDescending(i => i.Length).ToArray();

            if (!words.Any()) return stringStats;

            stringStats.NumberOfCharacters = subject.Length;
            stringStats.NumberOfWords = words.Length;
            stringStats.LongestWordNumberOfCharacters = Convert.ToInt64(words.FirstOrDefault()?.Length);

            return stringStats;
        }
    }
}
