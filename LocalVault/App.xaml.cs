using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LocalVault.Configuration;
using LocalVault.Crypto;
using LocalVault.Storage;

namespace LocalVault
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			MainWindow mainWindow = new MainWindow(new LocalVaultConfiguration(new AesService(), new FileStorageService()))
			{
				Title = "LocalVault"
			};
			mainWindow.Show();
		}
	}
}
