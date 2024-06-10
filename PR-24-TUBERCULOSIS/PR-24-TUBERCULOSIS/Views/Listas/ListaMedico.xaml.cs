using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PR_24_TUBERCULOSIS.Views;

namespace PR_24_TUBERCULOSIS
{
    public partial class ListaMedico : ContentView
    {
        public ObservableCollection<Medico> Medicos { get; set; }
        public ICommand EliminarCommand { get; }
        public ICommand DetalleCommand { get; }

        public ListaMedico()
        {
            InitializeComponent();

            Medicos = new ObservableCollection<Medico>
            {
                new Medico { Nombre = "Dr. Juan", Apellido = "Pérez", Detalle = "Detalles del médico Dr. Juan Pérez" },
                new Medico { Nombre = "Dra. María", Apellido = "González", Detalle = "Detalles del médico Dra. María González" },
            };

            EliminarCommand = new Command<Medico>(async (medico) => await Eliminar(medico));
            DetalleCommand = new Command<Medico>(Detalle);

            BindingContext = this;
        }

        private async Task Eliminar(Medico medico)
        {
            var result = await Application.Current.MainPage.DisplayAlert("Eliminar Médico", "¿Estás seguro de eliminar al médico?", "Sí", "No");

            if (result)
            {
                Medicos.Remove(medico);
            }
        }

        private async void Detalle(Medico medico)
        {
            await Application.Current.MainPage.DisplayAlert("Detalles del Médico", $"Nombre: {medico.Nombre}\nApellido: {medico.Apellido}\nDetalle: {medico.Detalle}", "Volver");
        }

        private async void OnVolverClicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new Menu());
        }

        private async void OnCrearDoctorClicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new CrearDoctor());
        }
        private async void OnEditarDoctorClicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new CrearDoctor());
        }
    }

    public class Medico
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Detalle { get; set; }
    }
}
