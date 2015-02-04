using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfDemoApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			// Toggle "pixel perfect mode" based on command-line switch :-)
			if (e.Args.Contains("--PixelPerfectMode"))
			{
				ResourceDictionary resourceDictionary = new ResourceDictionary { Source = new Uri("/WpfDemoApp;component/Themes/PixelPerfectTheme.xaml", UriKind.RelativeOrAbsolute) };
				this.Resources.MergedDictionaries.Add(resourceDictionary);
			}
		}
	}
}
