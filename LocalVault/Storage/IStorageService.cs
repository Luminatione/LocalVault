using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LocalVault.Storage
{
    public interface IStorageService
    {
	    BindingList<PasswordEntry> LoadAll();
	    void SaveAll(BindingList<PasswordEntry> entries);
    }
}
