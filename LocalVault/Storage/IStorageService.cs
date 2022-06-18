using System;
using System.Collections.Generic;
using System.Text;

namespace LocalVault.Storage
{
    public interface IStorageService
    {
	    List<PasswordEntry> LoadAll();
	    void SaveAll(List<PasswordEntry> entries);
    }
}
