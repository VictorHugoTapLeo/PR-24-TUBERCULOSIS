namespace PR_24_TUBERCULOSIS.Views.Doctor;
using PR_24_TUBERCULOSIS.Implementacion;
using PR_24_TUBERCULOSIS.Model;
using System.Data;
using System.Xml.Linq;
public partial class UpdateDoctor : ContentPage
{
    PersonalSalud p;
    PersonalImpl pImpl;
    int id;
    public UpdateDoctor(int Id)
	{
		InitializeComponent();
        pImpl = new PersonalImpl();
        id = Id;
        Get();
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
            DataTable dt = pImpl.Select();

            List<PersonalSalud> personal = new List<PersonalSalud>();

            foreach (DataRow dr in dt.Rows)
            {
                personal.Add(new PersonalSalud
                {
                    idPersona = Convert.ToInt32(dr["id"].ToString()),

                    //idPersona = Convert.ToInt32(dr["id"].ToString())
                });

            }
            //  GridData.ItemsSource = personal;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener los datos: " + ex.Message);
        }
    }
    void Get()
    {
        p = null;
        try
        {
            if (id > 0)
            {
                pImpl = new PersonalImpl(); // Inicializa pImpl antes de utilizarlo
                p = pImpl.Get(id);
                if (p != null)
                {
                    // Utiliza los campos del objeto PersonalSalud directamente
                    PrimerNombreEntry.Text = p.primerNombre;
                    SegundoNombreEntry.Text = p.segundoNombre;
                    PrimerApellidoEntry.Text = p.primerApellido;
                    SegundoApellidoEntry.Text = p.segundoApellido;
                    CIEntry.Text = p.ci;
                    CorreoEntry.Text = p.email;
                    TelefonoEntry.Text = p.celular.ToString();
                    UsuarioEntry.Text = p.usuario;
                    CodigoEntry.Text = p.codigoPersonalSalud;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        if (id > 0)
        {
            pImpl = new PersonalImpl();
            PersonalSalud p = new PersonalSalud(PrimerNombreEntry.Text,
            SegundoNombreEntry.Text, PrimerApellidoEntry.Text, SegundoApellidoEntry.Text, CIEntry.Text, CorreoEntry.Text,
            int.Parse(TelefonoEntry.Text),
            UsuarioEntry.Text,
            CodigoEntry.Text);
            pImpl.Update(p, id);

            DisplayAlert("Exito", "Los cambios fueron guardados correctamente", "OK");
            await Navigation.PushAsync(new ViewDoctor());

        }
    }

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewDoctor());
    }
}