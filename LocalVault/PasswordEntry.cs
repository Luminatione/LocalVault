using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace LocalVault
{
	public class PasswordEntry
	{
		public string Password { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }

		public PasswordEntry(string password, string name, string description)
		{
			Password = password;
			Name = name;
			Description = description;
		}
	}
}
