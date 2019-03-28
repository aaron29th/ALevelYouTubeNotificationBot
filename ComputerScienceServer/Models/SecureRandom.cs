﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YoutubeNotifyBot.Models.Youtube;
using Microsoft.AspNetCore.WebUtilities;

namespace YoutubeNotifyBot.Models
{
	public class SecureRandom
	{
		/// <summary>
		/// Returns secure random string
		/// </summary>
		/// <param name="length">Length of string to be returned</param>
		/// <returns>Secure random string</returns>
		public static string GetString(int length)
		{
			byte[] data = new byte[256];
			using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
			{
				rng.GetBytes(data);

				return Base64UrlTextEncoder.Encode(data).Substring(0, length);
			}
		}
	}
}
