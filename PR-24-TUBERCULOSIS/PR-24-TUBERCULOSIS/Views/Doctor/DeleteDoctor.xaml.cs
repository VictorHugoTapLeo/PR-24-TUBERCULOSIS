namespace PR_24_TUBERCULOSIS.Views.Doctor;
using PR_24_TUBERCULOSIS.Implementacion;
using PR_24_TUBERCULOSIS.Model;
using System.IO.Pipelines;
using System.Xml.Linq;


public partial class DeleteDoctor : ContentPage
{
    PersonalSalud p;
    PersonalImpl implPersonal;
    int id;
    public DeleteDoctor(int Id)
	{
		InitializeComponent();
        id = Id;
        Get();
    }
    void Get()
    {
        p = null;
        try
        {
            if (id > 0)
            {
                implPersonal = new PersonalImpl(); // Inicializa pImpl antes de utilizarlo
                p = implPersonal.Get(id);
                if (p != null)
                {
                    // Utiliza los campos del objeto PersonalSalud directamente
                    txtNombre.Text = p.primerNombre;
                    txtSegundoNombre.Text = p.segundoNombre;
                    txtPrimerApellido.Text = p.primerApellido;
                    txtSegundoApellido.Text = p.segundoApellido;
                    txtci.Text = p.ci;
                    txtcorreo.Text = p.email;
                    txtcelular.Text = p.celular.ToString();
                    txtusuario.Text = p.usuario;
                    txtcodigo.Text = p.codigoPersonalSalud;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private async void btnDelete_Clicked(object sender, EventArgs e)
    {
        if (id > 0)
        {
            implPersonal = new PersonalImpl();
            implPersonal.Delete1(id);


            DisplayAlert("Exito", "Se elimino correctamente", "OK");
            await Navigation.PushAsync(new ViewDoctor());

        }
    }

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewDoctor());
    }
}