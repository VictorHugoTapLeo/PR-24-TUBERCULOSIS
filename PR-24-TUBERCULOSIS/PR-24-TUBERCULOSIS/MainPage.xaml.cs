using Microsoft.Maui.Controls;

namespace PR_24_TUBERCULOSIS
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();


        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        // manejar click de navegacion de ventanas lista paciente y lista medico
        private async void OnVerListaPacientesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new ContentPage { Content = new ListaPaciente() }));
        }
        private async void OnVerListaMedicosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new ContentPage { Content = new ListaMedico() }));
        }
        private async void OnCrearKardexClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new ContentPage { Content = new CrearKardex() }));
        }

    }
}
