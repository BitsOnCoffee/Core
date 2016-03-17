using System;

namespace BitsOnCoffee.Core.Extensions
{
	public static class DateTimeExtensions
	{
		#region ToISO8601
		/// <summary>
		/// Returns string with ISO8601 formatted date/time. 
		/// </summary>
		/// <param name="dateTime">DateTime to format</param>
		/// <returns>Formatted string</returns>
		public static string ToISO8601(this DateTime dateTime)
		{
			return dateTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
		} 
		#endregion
	}
}
