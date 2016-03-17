using System.Text;

namespace BitsOnCoffee.Core.Cryptography
{
	/// <summary>
	/// Class for creating SHA256 hashes.
	/// </summary>
	public class SHA256
	{
		#region Hash
		/// <summary>
		/// Hashes the string to SHA256 Hash.
		/// </summary>
		/// <param name="text">String to be hashed</param>
		/// <returns>Hash</returns>
		public string Hash(string text)
		{
			var sha = System.Security.Cryptography.SHA256.Create();
			var inputBytes = Encoding.ASCII.GetBytes(text);
			var hash = sha.ComputeHash(inputBytes);

			var sb = new StringBuilder();
			for (var i = 0; i < hash.Length; i++)
			{
				sb.Append(hash[i].ToString("X2"));
			}
			return sb.ToString();
		} 
		#endregion
	}
}
