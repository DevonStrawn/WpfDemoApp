using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemoApp
{
	public class GlobalViewModel
	{
		public GlobalViewModel(List<ThemeModel> themes)
		{
			this.themes = new ObservableCollection<ThemeModel>(themes);
		}

		public ObservableCollection<ThemeModel> themes;

		public ObservableCollection<ThemeModel> Themes
		{
			get { return this.themes; }
		}
	}
}
