using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ComputerScienceServer.Models.Youtube;

namespace ComputerScienceServer.Models
{
	public class TextFormatter
	{
		/// <summary>
		/// Returns secure random string
		/// </summary>
		/// <param name="length">Length of string to be returned</param>
		/// <returns>Secure random string</returns>
		public static string SecureRandomString(int length)
		{
			byte[] data = new byte[256];
			using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
			{
				rng.GetBytes(data);

				return Convert.ToBase64String(data).Substring(0, length);
			}
		}
	}
}
