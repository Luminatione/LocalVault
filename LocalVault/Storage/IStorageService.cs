using System;
using System.Collections.Generic;
using System.Text;

namespace LocalVault.Storage
{
    public interface IStorageService<T>
    {
	    List<T> LoadAll();
	    void SaveAll(List<T> entries);
    }
}
