using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PR_24_TUBERCULOSIS.Views.Crear;

namespace PR_24_TUBERCULOSIS
{
    public partial class ListaBasiloscopia : ContentView
    {
        public ObservableCollection<Basiloscopia> Basiloscopia { get; set; }
        public ICommand EliminarCommand { get; }
        public ICommand DetalleCommand { get; }

        public ListaBasiloscopia()
        {
            InitializeComponent();

            Basiloscopia = new ObservableCollection<Basiloscopia>
            {
                new Basiloscopia { Nro = "1", Basiloscopiaa = "Basiloscopia A", Estado = "Activo" },
                new Basiloscopia { Nro = "2", Basiloscopiaa = "Basiloscopia B", Estado = "Inactivo" },
                new Basiloscopia { Nro = "3", Basiloscopiaa = "Basiloscopia C", Estado = "Activo" }
            };

            EliminarCommand = new Command<Basiloscopia>(async (basiloscopia) => await Eliminar(basiloscopia));
            DetalleCommand = new Command<Basiloscopia>(Detalle);

            BindingContext = this;
        }

        private async Task Eliminar(Basiloscopia basiloscopia)
        {
            var result = await Application.Current.MainPage.DisplayAlert("Eliminar Basiloscopia", "¿Estás seguro de eliminar la Basiloscopia?", "Sí", "No");

            if (result)
            {
                Basiloscopia.Remove(basiloscopia);
            }
        }

        private async void Detalle(Basiloscopia basiloscopia)
        {
            await Application.Current.MainPage.DisplayAlert("Detalles de la Basiloscopia", $"Nro: {basiloscopia.Nro}\nBasiloscopia: {basiloscopia.Basiloscopiaa}\nEstado: {basiloscopia.Estado}", "Volver");
        }

        private async void OnVolverClicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new ContentPage { Content = new ListaKardexPaciente() });
        }

        private async void OnNuevaBasiloscopiaClicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new CrearBaciloscopia());
        }
    }

    public class Basiloscopia
    {
        private string basiloscopia;

        public string Nro { get; set; }
        public string Basiloscopiaa { get => basiloscopia; set => basiloscopia = value; }
        public string Estado { get; set; }
    }
}
