using System.Data;
using PR_24_TUBERCULOSIS.Implementacion;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS;
using PR_24_TUBERCULOSIS.Views.Login;   

namespace PR_24_TUBERCULOSIS.Views.Listas;

public partial class ListaSeguimientoPeso : ContentPage
{
	public ListaSeguimientoPeso()
	{
        InitializeComponent();

        // Instancia de la implementación de SeguimientoPeso
        SeguimientoPesoImpl seguimientoPesoImpl = new SeguimientoPesoImpl();

        // Obtener datos de seguimientoPeso
        var seguimientoPesoData = seguimientoPesoImpl.Select().AsEnumerable();

        // Crear una lista de objetos SeguimientoPeso
        List<SeguimientoPeso> seguimientoPesoList = new List<SeguimientoPeso>();
        foreach (DataRow row in seguimientoPesoData)
        {
            seguimientoPesoList.Add(new SeguimientoPeso(0,0)
            {
                
                FechaRegistro = row["FechaRegistro"].ToString(),
                peso = byte.Parse(row["Peso"].ToString()),
                Paciente = row["Paciente"].ToString()
            });
        }

        // Establecer la lista como ItemsSource del TableView
        seguimientoPesoTableView.Root = new TableRoot
            {
                new TableSection("Seguimiento de Peso")
                {
                    // Agregar una fila por cada elemento en la lista
                    seguimientoPesoList.Select(item => new ViewCell
                    {
                        View = new StackLayout
                        {
                            Children =
                            {
                                new Label { Text = "Fecha de Registro: " + item.FechaRegistro },
                                new Label { Text = "Peso: " + item.peso +" Kilos"},
                                new Label { Text = "Paciente: " + item.Paciente }
                            }
                        }
                    })
                }
            };
    }
    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new MenuActividades());
    }
}
