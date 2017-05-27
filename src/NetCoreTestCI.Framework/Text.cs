using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace NetCoreTestCI.Framework
{
    public class Text
    {
        public static string RemoveDiacritics(string text, bool toLowerCase = false)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            Encoding srcEncoding = Encoding.UTF8;

            Encoding destEncoding = CodePagesEncodingProvider.Instance.GetEncoding(1252); //Latin alphabet

            text = destEncoding.GetString(Encoding.Convert(srcEncoding, destEncoding, srcEncoding.GetBytes(text)));

            string normalizedString = text.Normalize(NormalizationForm.FormD);
            var result = new StringBuilder();

            foreach (char ch in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(ch).Equals(UnicodeCategory.NonSpacingMark)) continue;
                result.Append(ch);
            }

            return toLowerCase ? result.ToString().ToLowerInvariant() : result.ToString();
        }

        public static string Slugify(string text, bool toLowerCase = true)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            text = RemoveDiacritics(text, toLowerCase);
            text = text.ToLowerInvariant();
            text = Regex.Replace(text, "[^a-z0-9]", " ", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"\s+", " ");
            text = text.Trim();
            text = text.Replace(" ", "-");
            return text;
        }
    }
}
