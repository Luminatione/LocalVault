using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace LocalVault.Storage
{
	public class FileStorageService : IStorageService
	{
		private readonly string filename;
		public FileStorageService(string filename)
		{
			this.filename = filename;
		}

		public BindingList<PasswordEntry> LoadAll()
		{
			try
			{
				using StreamReader reader = File.OpenText(filename);
				string fileContent = reader.ReadToEnd();
				return JsonConvert.DeserializeObject<BindingList<PasswordEntry>>(fileContent);
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine(e);
				return null;
			}

		}

		public void SaveAll(BindingList<PasswordEntry> entries)
		{
			using StreamWriter reader = new StreamWriter(File.Open(filename, FileMode.Create));
			reader.Write(JsonConvert.SerializeObject(entries));
		}
	}
}
