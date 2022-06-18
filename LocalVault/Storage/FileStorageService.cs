using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LocalVault.Storage
{
    public class FileStorageService : IStorageService<PasswordEntry>
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

	    }

	    public void SaveAll(List<PasswordEntry> entries)
	    {
		    throw new NotImplementedException();
	    }
    }
}
