using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace PR_24_TUBERCULOSIS
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new AppShell();
            
        }
	}
}