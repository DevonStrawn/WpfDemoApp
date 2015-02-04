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

namespace WpfDemoApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private GlobalViewModel viewModel;

		public MainWindow()
		{
			List<ThemeModel> themes = new List<ThemeModel>
			{
				new ThemeModel { Uri = new Uri("/WpfDemoApp;component/Themes/PurpleTheme.xaml", UriKind.RelativeOrAbsolute), Label = "Purple Theme" },
				new ThemeModel { Uri = new Uri("/WpfDemoApp;component/Themes/OrangeTheme.xaml", UriKind.RelativeOrAbsolute), Label = "Orange Theme" },
				new ThemeModel { Uri = new Uri("/WpfDemoApp;component/Themes/BlueTheme.xaml", UriKind.RelativeOrAbsolute), Label = "Blue Theme" },
			};

			this.viewModel = new GlobalViewModel(themes);
			ICollectionView collectionView = CollectionViewSource.GetDefaultView(viewModel.themes);
			collectionView.CurrentChanged += collectionView_CurrentChanged;
			this.DataContext = viewModel;

			InitializeComponent();
		}

		private void collectionView_CurrentChanged(object sender, EventArgs e)
		{
			ICollectionView collectionView = CollectionViewSource.GetDefaultView(viewModel.themes);
			if (collectionView == null)
			{
				return;
			}

			ThemeModel themeModel = collectionView.CurrentItem as ThemeModel;
			if (themeModel == null)
			{
				return;
			}

			// Clear out old theme.
			this.Resources.MergedDictionaries.Clear();

			// Add new theme.
			this.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = themeModel.Uri });
		}
	}
}
