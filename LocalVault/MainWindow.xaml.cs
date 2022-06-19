using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
		private LocalVaultConfiguration configuration;

		public BindingList<PasswordEntry> PasswordEntries { get; }

		private byte[] vi = { 0x2, 0x1, 0x3, 0x7};

		public MainWindow(LocalVaultConfiguration configuration)
		{
			this.configuration = configuration;
			InitializeComponent();
			DataContext = this;
			PasswordEntries = configuration.StorageService.LoadAll() ?? new BindingList<PasswordEntry>();

		}

		private void EncryptButton_Click(object sender, RoutedEventArgs e)
		{
			foreach (PasswordEntry passwordEntry in PasswordEntries)
			{
				passwordEntry.Description =
					configuration.CryptoService.Encrypt(passwordEntry.Description, PasswordTextBox.Text, vi);
			}
		}

		private void DecryptButton_Click(object sender, RoutedEventArgs e)
		{
			foreach (PasswordEntry passwordEntry in PasswordEntries)
			{
				passwordEntry.Description =
					configuration.CryptoService.Decrypt(passwordEntry.Description, PasswordTextBox.Text, vi);
			}
		}

		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			PasswordEntries.Add(new PasswordEntry(string.Empty, "New Item", string.Empty));
		}

		private void RemoveButton_Click(object sender, RoutedEventArgs e)
		{
			PasswordEntries.Remove((PasswordEntry)PasswordEntriesListBox.SelectedItems[0] ?? new PasswordEntry());
		}
	}
}
