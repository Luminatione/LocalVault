using System;
using System.Collections.Generic;
using System.Text;

namespace LocalVault.Crypto
{
    public interface ICryptoService
    {
	    String Encrypt(String str, params Object[] args);
	    String Decrypt(String str, params Object[] args);
    }
}
