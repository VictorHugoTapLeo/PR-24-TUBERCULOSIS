using System;
using Microsoft.Maui.Controls;

namespace PR_24_TUBERCULOSIS
{
    public partial class CrearKardex : ContentView
    {
        public CrearKardex()
        {
            InitializeComponent();
        }

        private bool CamposEstanLlenos()
        {
            
            if (string.IsNullOrWhiteSpace(TipoTuberculosisEntry.Text) ||
                string.IsNullOrWhiteSpace(PesoInicialEntry.Text) ||
                string.IsNullOrWhiteSpace(BaciloscopiaEntry.Text) ||
                string.IsNullOrWhiteSpace(CondicionEgresoEntry.Text) ||
                string.IsNullOrWhiteSpace(TransferenciaEntry.Text) ||
                string.IsNullOrWhiteSpace(DiagnosticoEntry.Text) ||
                string.IsNullOrWhiteSpace(EsquemaTratamientoEntry.Text) ||
                string.IsNullOrWhiteSpace(DocificacionEntry.Text) ||
                string.IsNullOrWhiteSpace(CultivoControlEntry.Text) ||
                string.IsNullOrWhiteSpace(NumeroDosisEntry.Text) ||
                string.IsNullOrWhiteSpace(TallaEntry.Text) ||
                string.IsNullOrWhiteSpace(PlanificadorControlesEntry.Text) ||
                string.IsNullOrWhiteSpace(PesoFinalEntry.Text) ||
                string.IsNullOrWhiteSpace(TransferenciaAEntry.Text))
            {
                return false;
            }

            
            if (FechaInicioDatePicker.Date == null ||
                FechaDiagnosticoDatePicker.Date == null)
            {
                return false;
            }

            return true;
        }

        private async void RegistrarButton_Clicked(object sender, EventArgs e)
        {
            if (CamposEstanLlenos())
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Datos registrados correctamente", "Aceptar");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, complete todos los campos", "Aceptar");
            }
        }


        private async void CancelarButton_Clicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new ContentPage { Content = new ListaKardexPaciente() });
        }

    }
}
