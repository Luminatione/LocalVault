﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LocalVault.Crypto
{
	public class AesService : ICryptoService
	{
		private void checkArguments(string str, byte[] key, byte[] IV)
		{
			if (str == null || str.Length <= 0)
				throw new ArgumentNullException(nameof(str));
			if (key == null || key.Length <= 0)
				throw new ArgumentNullException(nameof(key));
			if (IV == null || IV.Length <= 0)
				throw new ArgumentNullException(nameof(IV));
		}


		//https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-6.0
		private string Encrypt(string str, byte[] key, byte[] iv)
		{
			checkArguments(str, key, iv);
			using Aes aesAlg = Aes.Create();
			aesAlg.Key = key;
			aesAlg.IV = iv;

			ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
			//str is transformed by encryptor and written in MemoryStream by StreamWriter and then encrypted test is retrieved by StreamReader
			MemoryStream msEncrypt = new MemoryStream();
			using StreamWriter swEncrypt = new StreamWriter(new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write));
			swEncrypt.Write(str);

			return new StreamReader(msEncrypt).ReadToEnd();
		}


		string Decrypt(string cipherText, byte[] key, byte[] iv)
		{
			checkArguments(cipherText, key, iv);
			using Aes aesAlg = Aes.Create();
			aesAlg.Key = key;
			aesAlg.IV = iv;

			ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
			//cipherText is transformed by decryptor in CryptoStream and read by StreamReader
			using StreamReader decryptorStream = new StreamReader(new CryptoStream(new MemoryStream(Encoding.BigEndianUnicode.GetBytes(cipherText)), decryptor, CryptoStreamMode.Read));
			string plaintext = decryptorStream.ReadToEnd();

			return plaintext;
		}


        public string Encrypt(string str, params object[] args)
		{
			return Encrypt(str, (byte[])args[0], (byte[])args[1]);
		}

		public string Decrypt(string str, params object[] args)
		{
			return Decrypt(str, (byte[]) args[0], (byte[]) args[1]);
		}
	}
}
