namespace PR_24_TUBERCULOSIS.Views.ParteMovil;

public partial class ScanerQr : ContentPage
{
    private bool isScanning;
    public ScanerQr()
	{
		InitializeComponent();
        barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
        {
            Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
            AutoRotate = true,
            Multiple = true
        };
        isScanning = true;
    }
    private void barcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        var first = e.Results?.FirstOrDefault();
        if (first != null && isScanning)
        {
            isScanning = false; // Detener m�s escaneos
            Dispatcher.DispatchAsync(async () =>
            {
                // Navegar a la nueva p�gina DetalleQrPage pasando los datos del QR
                await Navigation.PushAsync(new DetalleQr(first.Value));
            });
        }
    }
}