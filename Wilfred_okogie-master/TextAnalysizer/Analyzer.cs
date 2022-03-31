namespace TextAnalyzer
{
    public class Analyzer
    {
        private readonly Dictionary<char, int> analyzer = new();
        public Analyzer(string text)
        {
            Text = text;
        }
        public string Text { get; set; }        

        /// <summary>
        /// Gets the total number of sentences
        /// </summary>
        /// <returns></returns>
        public int CountSentences()
        {
            return Sentences(Text).Length;
        }

        /// <summary>
        /// Gets the total number of vowels in the whole texts
        /// </summary>
        /// <returns></returns>
        public int CountVowels()
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            return CleanText().Count(x => vowels.Contains(x));
        }

        /// <summary>
        /// Gets the total number of consonants in the whole texts
        /// </summary>
        /// <returns></returns>
        public int CountConsonant()
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            return CleanText().Count(x => !vowels.Contains(x));
        }

        /// <summary>
        /// Gets the total number of upper case letters
        /// </summary>
        /// <returns></returns>
        public int CountUpperCaseLetters()
        {
            return CleanText().Count(x => char.IsUpper(x));
        }

        /// <summary>
        /// Gets the total number of lower case letters
        /// </summary>
        /// <returns></returns>
        public int CountLowerCaseLetters()
        {
            return CleanText().Count(x => char.IsLower(x));
        }       

        /// <summary>
        /// Gets the total number for each letter
        /// </summary>
        /// <returns></returns>
        public Dictionary<char, int> CountIndividualLetters()
        {
            var text = CleanText();

            foreach (char character in text)
            {
                if (analyzer.ContainsKey(character))
                {
                    analyzer[character] += 1;
                }
                else
                {
                    analyzer[character] = 1;
                }
            }

            return analyzer;
        }

        /// <summary>
        /// Removes all other characters except letters
        /// </summary>
        /// <returns></returns>
        private string CleanText()
        {
            return string.Join("", FlattenSentences().Where(x => char.IsLetter(x)));
        }

        /// <summary>
        /// Groups the multi-line sentences into a single string
        /// </summary>
        /// <returns></returns>
        private string FlattenSentences()
        {
            var sentences = Text.Split("*").ToArray();
            var str = string.Join("", sentences);

            return str;
        }

        public static bool ValidateText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            return true;
        }

        /// <summary>
        /// Gets the sentences in a array
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string[] Sentences(string text)
        {
            var lines = text.Split("*").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            return lines;
        }
    }
}
