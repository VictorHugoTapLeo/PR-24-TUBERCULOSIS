namespace PR_24_TUBERCULOSIS.Views.Doctor;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS.Implementacion;
using System.Data;
public partial class ViewDoctor : ContentPage
{
    PersonalImpl implPersonal;
    int id = 0;
    int idb = 0;
    public ViewDoctor()
	{
		InitializeComponent();
        implPersonal = new PersonalImpl();
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
            DataTable dt = implPersonal.Select();

            List<PersonalSalud> tutores = new List<PersonalSalud>();

            foreach (DataRow dr in dt.Rows)
            {
                tutores.Add(new PersonalSalud
                {
                    primerNombre = dr["Nombre"].ToString(),
                    primerApellido = dr["Apellido"].ToString(),
                    segundoApellido = dr["segundoApellido"].ToString(),
                    ci = dr["CI"].ToString(),
                    idPersona = Convert.ToInt32(dr["id"].ToString())
                });

            }

            GridData.ItemsSource = tutores;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener los datos: " + ex.Message);
        }
    }

    private async void OnCrearDoctorClicked(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new CrearDoctor());
    }

    private async void EditarDoctorClicked(object sender, EventArgs e)
    {

        var selectedTutor = (sender as Button)?.CommandParameter as PersonalSalud;
        if (selectedTutor != null)
        {
            idb = selectedTutor.idPersona;

            await Navigation.PushAsync(new UpdateDoctor(selectedTutor.idPersona));
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private async void EliminarClicked(object sender, EventArgs e)
    {

        var selectedTutor = (sender as Button)?.CommandParameter as PersonalSalud;
        if (selectedTutor != null)
        {
            idb = selectedTutor.idPersona;

            await Navigation.PushAsync(new DeleteDoctor(selectedTutor.idPersona));
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new Menu());
    }
}
