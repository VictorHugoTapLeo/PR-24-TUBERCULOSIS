namespace PR_24_TUBERCULOSIS.Views.Kardex;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS.Implementacion;
using System.Data;
using PR_24_TUBERCULOSIS.Views.Paciente;

public partial class ViewKardex : ContentPage
{
    KardexImpl implKardex;
    int id = 0;
    int idb = 0;
    public ViewKardex()
	{
		InitializeComponent();

        lblListaKardex.Text = ("Lista Kardex " + AtributosPaciente.Name + " " + AtributosPaciente.LastName);
        implKardex = new KardexImpl();
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
            DataTable dt = implKardex.Select();

            List<KardexModel> kardex = new List<KardexModel>();

            foreach (DataRow dr in dt.Rows)
            {
                kardex.Add(new KardexModel
                {
                    fechacreacion = Convert.ToDateTime(dr["Fecha"].ToString()),
                    tipoTuberculosis = dr["Tipo Tuberculosis"].ToString(),
                    docificacionMedicamentos = dr["Docificacion"].ToString(),
                    idKardex = Convert.ToInt32(dr["id"].ToString())
                });

            }

            GridData.ItemsSource = kardex;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener los datos: " + ex.Message);
        }
    }

    private async void OnCrearDoctorClicked(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new CrearKardex());//crear kardex
    }



    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NavigationPage(new ContentPage { Content = new ListaPacientes() }));
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new MenuActividades());//menu actividades
    }

    private async void Button_Clicked_3(object sender, EventArgs e)
    {
        var selectedTutor = (sender as Button)?.CommandParameter as KardexModel;
        if (selectedTutor != null)
        {
            idb = selectedTutor.idKardex;
            AtributosPaciente.CardexId = selectedTutor.idKardex;
            await Navigation.PushAsync(new DetallesKardex());
        }
    }
}
