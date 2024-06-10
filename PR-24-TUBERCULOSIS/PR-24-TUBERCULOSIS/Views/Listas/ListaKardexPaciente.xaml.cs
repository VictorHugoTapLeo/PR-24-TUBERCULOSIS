using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace PR_24_TUBERCULOSIS;

public partial class ListaKardexPaciente : ContentView
{
    public ObservableCollection<Kardex> Kardex { get; set; }
    public ICommand EliminarCommand { get; }
    public ICommand DetalleCommand { get; }
    public ICommand ListaBaciloscopiaCommand { get; }
    public ListaKardexPaciente()
	{
        InitializeComponent();

        Kardex = new ObservableCollection<Kardex>
            {
                new Kardex { Fecha = "01/01/2022", Tratamiento = "Tratamiento A", Medicamento = "Medicamento A" },
                new Kardex { Fecha = "02/01/2022", Tratamiento = "Tratamiento B", Medicamento = "Medicamento B" },
                new Kardex { Fecha = "01/01/2022", Tratamiento = "Tratamiento A", Medicamento = "Medicamento A" },
                new Kardex { Fecha = "02/01/2022", Tratamiento = "Tratamiento B", Medicamento = "Medicamento B" },
                
            };

        EliminarCommand = new Command<Kardex>(async (kardex) => await Eliminar(kardex));
        DetalleCommand = new Command<Kardex>(Detalle);
        ListaBaciloscopiaCommand = new Command<Kardex>(ListaBaciloscopia);

        BindingContext = this;
    }

    private async Task Eliminar(Kardex kardex)
    {
        var result = await Application.Current.MainPage.DisplayAlert("Eliminar Kardex", "¿Estás seguro de eliminar el Kardex?", "Sí", "No");

        if (result)
        {
            Kardex.Remove(kardex);
        }
    }

    private async void Detalle(Kardex kardex)
    {
        await Application.Current.MainPage.DisplayAlert("Detalles del Kardex", $"Fecha: {kardex.Fecha}\nTratamiento: {kardex.Tratamiento}\nMedicamento: {kardex.Medicamento}", "Volver");
    }

    private void ListaBaciloscopia(Kardex kardex)
    {
        
    }

    private async void OnVolverClicked(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new ContentPage { Content = new ListaPaciente() });
    }

    private async void OnNuevoKardexClicked(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new ContentPage { Content = new CrearKardex() });
    }
    private async void OnListaBasiloscopia(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new ContentPage { Content = new ListaBasiloscopia() });
    }
}

public class Kardex
{
    public string Fecha { get; set; }
    public string Tratamiento { get; set; }
    public string Medicamento { get; set; }
}