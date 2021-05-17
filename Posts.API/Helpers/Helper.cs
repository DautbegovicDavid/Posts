using System.Globalization;
using System.Text;

namespace Posts.API.Helpers
{
    public class Helper
    {
        public static string GenerateSlug(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            string temp = sb.ToString().Normalize(NormalizationForm.FormC).ToLower().Replace(" ", "-");

            sb = new StringBuilder();

            foreach (char c in temp)
            {
                if (c == '-')
                    sb.Append(c);
                if (!char.IsPunctuation(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
