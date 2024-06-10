using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS.Views;

namespace PR_24_TUBERCULOSIS
{
    public partial class ListaPaciente : ContentView
    {
        public ObservableCollection<Paciente> Pacientes { get; set; }
        public ICommand EliminarCommand { get; }
        public ICommand DetalleCommand { get; }

        public ListaPaciente()
        {
            InitializeComponent();

            Pacientes = new ObservableCollection<Paciente>
            {
                new Paciente { Nombre = "Juan", Apellido = "P�rez", Detalle = "Detalles del paciente Juan P�rez" },
                new Paciente { Nombre = "Mar�a", Apellido = "Gonz�lez", Detalle = "Detalles del paciente Mar�a Gonz�lez" },
                new Paciente { Nombre = "Juan", Apellido = "P�rez", Detalle = "Detalles del paciente Juan P�rez" },
                new Paciente { Nombre = "Mar�a", Apellido = "Gonz�lez", Detalle = "Detalles del paciente Mar�a Gonz�lez" },
                new Paciente { Nombre = "Juan", Apellido = "P�rez", Detalle = "Detalles del paciente Juan P�rez" },
                new Paciente { Nombre = "Mar�a", Apellido = "Gonz�lez", Detalle = "Detalles del paciente Mar�a Gonz�lez" },
                new Paciente { Nombre = "Juan", Apellido = "P�rez", Detalle = "Detalles del paciente Juan P�rez" },
                new Paciente { Nombre = "Mar�a", Apellido = "Gonz�lez", Detalle = "Detalles del paciente Mar�a Gonz�lez" },
                new Paciente { Nombre = "Juan", Apellido = "P�rez", Detalle = "Detalles del paciente Juan P�rez" },
                new Paciente { Nombre = "Mar�a", Apellido = "Gonz�lez", Detalle = "Detalles del paciente Mar�a Gonz�lez" },
                new Paciente { Nombre = "Juan", Apellido = "P�rez", Detalle = "Detalles del paciente Juan P�rez" },
                new Paciente { Nombre = "Mar�a", Apellido = "Gonz�lez", Detalle = "Detalles del paciente Mar�a Gonz�lez" },
                new Paciente { Nombre = "Juan", Apellido = "P�rez", Detalle = "Detalles del paciente Juan P�rez" },
                new Paciente { Nombre = "Mar�a", Apellido = "Gonz�lez", Detalle = "Detalles del paciente Mar�a Gonz�lez" },
                new Paciente { Nombre = "Juan", Apellido = "P�rez", Detalle = "Detalles del paciente Juan P�rez" },
                new Paciente { Nombre = "Mar�a", Apellido = "Gonz�lez", Detalle = "Detalles del paciente Mar�a Gonz�lez" },
                new Paciente { Nombre = "Juan", Apellido = "P�rez", Detalle = "Detalles del paciente Juan P�rez" },
                new Paciente { Nombre = "Mar�a", Apellido = "Gonz�lez", Detalle = "Detalles del paciente Mar�a Gonz�lez" },
                new Paciente { Nombre = "Juan", Apellido = "P�rez", Detalle = "Detalles del paciente Juan P�rez" },
                new Paciente { Nombre = "Mar�a", Apellido = "Gonz�lez", Detalle = "Detalles del paciente Mar�a Gonz�lez" },
                new Paciente { Nombre = "Juan", Apellido = "P�rez", Detalle = "Detalles del paciente Juan P�rez" },
                new Paciente { Nombre = "Mar�a", Apellido = "Gonz�lez", Detalle = "Detalles del paciente Mar�a Gonz�lez" },
                new Paciente { Nombre = "Juan", Apellido = "P�rez", Detalle = "Detalles del paciente Juan P�rez" },
                new Paciente { Nombre = "Mar�a", Apellido = "Gonz�lez", Detalle = "Detalles del paciente Mar�a Gonz�lez" },
                new Paciente { Nombre = "Juan", Apellido = "P�rez", Detalle = "Detalles del paciente Juan P�rez" },
                new Paciente { Nombre = "Mar�a", Apellido = "Gonz�lez", Detalle = "Detalles del paciente Mar�a Gonz�lez" },
            };

            EliminarCommand = new Command<Paciente>(async (paciente) => await Eliminar(paciente));
            DetalleCommand = new Command<Paciente>(Detalle);

            BindingContext = this;
        }

        private async Task Eliminar(Paciente paciente)
        {
            var result = await Application.Current.MainPage.DisplayAlert("Eliminar Paciente", "�Est�s seguro de eliminar al paciente?", "S�", "No");

            if (result)
            {
                Pacientes.Remove(paciente);
            }
        }

        private async void Detalle(Paciente paciente)
        {
            await Application.Current.MainPage.DisplayAlert("Detalles del Paciente", $"Nombre: {paciente.Nombre}\nApellido: {paciente.Apellido}\nDetalle: {paciente.Detalle}", "Volver");
        }
        private async void OnVolverClicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new Menu());
        }

        private async void OnCrearPacienteClicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new CrearPaciente());
        }
        private async void OnNuevoKardexClicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new ContentPage { Content = new ListaKardexPaciente() });
        }
    }
    
    public class Paciente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Detalle { get; set; }
    }
}
