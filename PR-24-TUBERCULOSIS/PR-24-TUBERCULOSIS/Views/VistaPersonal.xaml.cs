namespace PR_24_TUBERCULOSIS.Views;

using System.Data;
using PR_24_TUBERCULOSIS.Implementacion;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS;
using PR_24_TUBERCULOSIS.Views.Login;

public partial class VistaPersonal : ContentPage
{
    public VistaPersonal()
    {
        InitializeComponent();

        // Instancia de la implementación de PersonalSalud
        PersonaImpl personalSaludImpl = new PersonaImpl();

        // Obtener datos de personalSalud
        var personalSaludData = personalSaludImpl.Select().AsEnumerable();

        // Crear una lista de objetos PersonalSalud
        List<Persona> personalSaludList = new List<Persona>();
        foreach (DataRow row in personalSaludData)
        {
            personalSaludList.Add(new Persona
            {
                usuario = row["usuario"].ToString()
            });
        }

        // Establecer la lista como ItemsSource del TableView
        personalSaludTableView.Root = new TableRoot
            {
                new TableSection("Usuario")
                {
                    // Agregar una fila por cada elemento en la lista
                    personalSaludList.Select(item => new ViewCell


                    {
                        View = new StackLayout
                        {
                            Children =
                            {
                                new Label { Text = "Nombre de usuario: " + item.usuario
                                }

                            }
                        }
                    })
                }
            };
    }
}
