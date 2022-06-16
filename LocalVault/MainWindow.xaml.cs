using System;
using System.Collections.Generic;
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
		public MainWindow(LocalVaultConfiguration configuration)
		{
			this.configuration = configuration;
			InitializeComponent();
		}

		private void EncryptButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void DecryptButton_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
