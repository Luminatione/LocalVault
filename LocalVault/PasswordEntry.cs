using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using LocalVault.Crypto;


namespace LocalVault
{
	public class PasswordEntry
	{
		public string Password { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public PasswordEntry()
		{
			
		}

		public PasswordEntry(string password, string name, string description)
		{
			Password = password;
			Name = name;
			Description = description;
		}

		
	}
}
