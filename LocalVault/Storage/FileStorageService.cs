using System;
using System.Collections.Generic;
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

	    public List<PasswordEntry> LoadAll()
	    {
		    using StreamReader reader = File.OpenText(filename);
		    string fileContent = reader.ReadToEnd();
			return JsonConvert.DeserializeObject<List<PasswordEntry>>(fileContent);
	    }

	    public void SaveAll(List<PasswordEntry> entries)
	    {
		    using StreamWriter reader = new StreamWriter(File.OpenWrite(filename));
		    reader.Write(JsonConvert.SerializeObject(entries));
	    }
    }
}
