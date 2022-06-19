using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LocalVault.Configuration;
using LocalVault.Crypto;
using LocalVault.Storage;

namespace LocalVault
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private bool isEncrypted = true;
		private bool IsEncrypted
		{
			get => isEncrypted;
			set
			{
				isEncrypted = value;
				SetButtonsEnableState(!value);
			}
		}

		private LocalVaultConfiguration configuration;

		public BindingList<PasswordEntry> PasswordEntries { get; private set; }

		private byte[] vi = { 0x2, 0x1, 0x3, 0x7, 0x2, 0x1, 0x3, 0x7, 0x2, 0x1, 0x3, 0x7, 0x2, 0x1, 0x3, 0x7 };

		public MainWindow(LocalVaultConfiguration configuration)
		{
			this.configuration = configuration;
			InitializeComponent();
			DataContext = this;
			PasswordEntries = configuration.StorageService.LoadAll() ?? new BindingList<PasswordEntry>();
			IsEncrypted = PasswordEntries.Count != 0;
		}

		private void EncryptButton_Click(object sender, RoutedEventArgs e)
		{
			foreach (PasswordEntry passwordEntry in PasswordEntries)
			{
				passwordEntry.Description =
					configuration.CryptoService.Encrypt(passwordEntry.Description, GetFixedSizeUserKey(), vi);
				passwordEntry.Password =
					configuration.CryptoService.Encrypt(passwordEntry.Password, GetFixedSizeUserKey(), vi);
			}
			configuration.StorageService.SaveAll(PasswordEntries);
			IsEncrypted = true;
		}

		private void DecryptButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				foreach (PasswordEntry passwordEntry in PasswordEntries)
				{
					passwordEntry.Description =
						configuration.CryptoService.Decrypt(passwordEntry.Description, GetFixedSizeUserKey(), vi);
					passwordEntry.Password =
						configuration.CryptoService.Decrypt(passwordEntry.Password, GetFixedSizeUserKey(), vi);
				}

				IsEncrypted = false;
			}
			catch (CryptographicException)
			{
				MessageBox.Show("Invalid key - decryption failed");
			}
		}

		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			PasswordEntries.Add(new PasswordEntry(string.Empty, "New Item", string.Empty));
			configuration.StorageService.SaveAll(PasswordEntries);
		}

		private void RemoveButton_Click(object sender, RoutedEventArgs e)
		{
			PasswordEntries.Remove((PasswordEntry)PasswordEntriesListBox.SelectedItems[0] ?? new PasswordEntry());
			configuration.StorageService.SaveAll(PasswordEntries);
		}

		private string GetFixedSizeUserKey()
		{
			if (PasswordTextBox.Text.Length > 16)
			{
				return new string(PasswordTextBox.Text.ToCharArray(), 0, 32);
			}
			string result = PasswordTextBox.Text;
			result += new string('0', 16 - result.Length);
			return result;
		}

		private void SetButtonsEnableState(bool state)
		{
			AddButton.IsEnabled = state;
			RemoveButton.IsEnabled = state;
			EncryptButton.IsEnabled = state;
			DecryptButton.IsEnabled = !state;
		}
	}
}
