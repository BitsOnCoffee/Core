using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BitsOnCoffee.Core.Extensions
{
	public static class StringExtensions
	{
		#region IsEmail
		/// <summary>
		/// Checks if the string is a valid emamil address. <a href="http://msdn.microsoft.com/en-us/library/01escwtf(v=vs.110).aspx">MSDN: Verify that Strings Are in Valid Email Format</a>
		/// </summary>
		/// <param name="text">String to be checked</param>
		/// <returns>Result</returns>
		public static bool IsEmail(this string text)
		{
			return Regex.IsMatch(text,
				@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
				@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,24}))$",
				RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
		} 
		#endregion

		#region IsNumber
		/// <summary>
		/// Checks if the string is number.
		/// </summary>
		/// <param name="text">String to be checked</param>
		/// <returns>Result</returns>
		public static bool IsNumber(this string text)
		{
			double number;
			return double.TryParse(text, out number);
		} 
		#endregion

		#region ToFirstUpper
		/// <summary>
		/// Returns the string with the first uppercase letter.
		/// </summary>
		/// <param name="text">String to be edited</param>
		/// <returns>Edited string</returns>
		public static string ToFirstUpper(this string text)
		{
			char[] array = text.ToArray();
			array[0] = char.ToUpper(array[0]);
			return new string(array);
		} 
		#endregion

		#region ToUrlFormat
		/// <summary>
		/// Removes diacritics, keeps only letters and numbers, replaces spaces for hyphens.
		/// </summary>
		/// <param name="text">String to be edited</param>
		/// <returns>Edited string</returns>
		public static string ToUrlFormat(this string text)
		{
			text = RemoveDiacritics(text);
			text = new string(text.Where(s => char.IsLetterOrDigit(s) || s == ' ' || s == '-' || s == '_').ToArray());
			text = text.Replace(" ", "-");
			return text.ToLower();
		} 
		#endregion

		#region RemoveDiacritics
		/// <summary>
		/// Removes diacritics from the string.
		/// </summary>
		/// <param name="text">String to be edited.</param>
		/// <returns>Edited string</returns>
		public static string RemoveDiacritics(this string text)
		{
			text = text.Normalize(NormalizationForm.FormD);
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < text.Length; i++)
			{
				if (CharUnicodeInfo.GetUnicodeCategory(text[i]) != UnicodeCategory.NonSpacingMark) sb.Append(text[i]);
			}

			return sb.ToString();
		} 
		#endregion

		#region TrimIfNeeded
		/// <summary>
		/// Trims the string to specified length if needed (three dots are added at the end), otherwise returns the string itself.
		/// </summary>
		/// <param name="text">String to be trimmed</param>
		/// <param name="length">Length to which the string would be trimmed</param>
		/// <returns>Edited string</returns>
		public static string TrimIfNeeded(this string text, int length)
		{
			if (text.Length > length)
			{
				return string.Format("{0}...", text.Substring(0, length - 3));
			}
			return text;
		} 
		#endregion

		#region RemoveHtmlTags
		/// <summary>
		/// Removes all html tags, but keeps their content on place.
		/// </summary>
		/// <param name="text">String to be edited</param>
		/// <returns>Edited string</returns>
		public static string RemoveHtmlTags(this string text)
		{
			return Regex.Replace(text, "<.*?>", String.Empty);
		} 
		#endregion
	}
}
