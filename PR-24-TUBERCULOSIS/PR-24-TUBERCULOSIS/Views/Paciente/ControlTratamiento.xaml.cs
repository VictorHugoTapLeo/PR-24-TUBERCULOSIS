namespace PR_24_TUBERCULOSIS.Views.Paciente;
using PR_24_TUBERCULOSIS.Implementacion;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS.Views.Listas;

public partial class ControlTratamiento : ContentPage
{
    public ControlTratamiento()
    {
        InitializeComponent();
        LoadGenexpertData(AtributosPaciente.UserId);
    }

    private void LoadGenexpertData(int personaId)
    {
        try
        {
            var controlTratamientoImpl = new ControlTratamientoImpl();
            string genexpertValue = controlTratamientoImpl.GetGenexpertForPersona(personaId);
            txtGenexpert.Text = genexpertValue;
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"Ocurrió un error al cargar los datos de Genexpert: {ex.Message}", "OK");
        }
    }

    private async void OnRegistrarClicked(object sender, EventArgs e)
    {
        try
        {
            if (pickerBasiloscopia.SelectedItem == null)
            {
                await DisplayAlert("Error", "Por favor, selecciona una opción de Basiloscopia.", "OK");
                return;
            }

            if (pickerCultivo.SelectedItem == null)
            {
                await DisplayAlert("Error", "Por favor, selecciona una opción de Cultivo.", "OK");
                return;
            }

            if (pickerAumentoDosis.SelectedItem == null)
            {
                await DisplayAlert("Error", "Por favor, selecciona una opción de Aumento de Dosis.", "OK");
                return;
            }

            if (pickerNumeroBasiloscopia.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Por favor, selecciona un número de Basiloscopia.", "OK");
                return;
            }

            string basiloscopia = pickerBasiloscopia.SelectedItem.ToString();
            string cultivo = pickerCultivo.SelectedItem.ToString();
            string aumentoDosis = pickerAumentoDosis.SelectedItem.ToString();
            int ordenIdOrden = pickerNumeroBasiloscopia.SelectedIndex + 1;

            var controlTratamiento = new ClControlTratamiento(0, basiloscopia, cultivo, aumentoDosis, 14, ordenIdOrden);
            var controlTratamientoImpl = new ControlTratamientoImpl();
            int result = controlTratamientoImpl.Insert(controlTratamiento);

            if (result > 0)
            {
                await DisplayAlert("Éxito", "Control de tratamiento registrado correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Hubo un problema al registrar el control de tratamiento", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }

        await Navigation.PushAsync(new ListaControlTratmiento());
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new MenuActividades());
    }
}
