namespace PR_24_TUBERCULOSIS.Views.Listas;
using PR_24_TUBERCULOSIS.Implementacion;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS.Views.Paciente;
using System.Data;

public partial class ListaControlTratmiento : ContentPage
{
    ControlTratamiento trat;
    ControlTratamientoImpl tratamientoImpl;
    public ListaControlTratmiento()
	{
		InitializeComponent();
        //implPersonal = new PersonalImpl();
        tratamientoImpl = new ControlTratamientoImpl();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Select();
    }
    public void Select()
    {
        try
        {
            DataTable dt = tratamientoImpl.Select();

            List<ClControlTratamiento> trat = new List<ClControlTratamiento>();

            foreach (DataRow dr in dt.Rows)
            {
                trat.Add(new ClControlTratamiento
                {
                    //  primerNombre = dr["Nombre"].ToString(),
                    Basiloscopia = dr["basiloscopia"].ToString(),
                    Cultivo = dr["cultivo"].ToString(),
                    AumentoDosis = dr["aumentoDosis"].ToString(),
                    genExpert = dr["genExpert"].ToString(),
                    Nombre = dr["Nombre Paciente"].ToString()
                });

            }

            GridData.ItemsSource = trat;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener los datos: " + ex.Message);
        }
    }
    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new MenuActividades());
    }
}