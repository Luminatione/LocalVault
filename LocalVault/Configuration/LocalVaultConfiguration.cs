using System;
using System.Collections.Generic;
using System.Text;
using LocalVault.Crypto;
using LocalVault.Storage;

namespace LocalVault.Configuration
{
    public class LocalVaultConfiguration
    {
	    public LocalVaultConfiguration(ICryptoService cryptoService, IStorageService storageService)
	    {
		    this.CryptoService = cryptoService;
		    this.StorageService = storageService;
	    }

	    public ICryptoService CryptoService { get; }

	    public IStorageService StorageService { get; }
    }
}
