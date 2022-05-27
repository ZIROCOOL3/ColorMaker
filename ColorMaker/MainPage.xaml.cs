using CommunityToolkit.Maui.Alerts;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
    bool esAleatorio;
    string ValorHex;

    public MainPage()
	{
		InitializeComponent();
	}
    private void SliderValorCambiado(object sender, ValueChangedEventArgs e)
    {
        if (!esAleatorio)
        {
            var rojo = SldRojo.Value;
            var verde = SldVerde.Value;
            var azul = SldAzul.Value;

            Color color = Color.FromRgb(rojo, verde, azul);

            SetearColor(color);
        }
		

    }

    private void SetearColor(Color color)
    {
        btnAleatorio.BackgroundColor = color;
        Contenedor.BackgroundColor = color;
        ValorHex= color.ToHex();
        lblHex.Text = ValorHex;
    }

    private void btnAleatorio_presionado(object sender, EventArgs e)
    {
        esAleatorio = true;
        var random = new Random();

        var color = Color.FromRgb
            (
            random.Next(0, 256),
            random.Next(0, 256),
            random.Next(0, 256)
            );
        SetearColor(color);

        SldRojo.Value = color.Red;
        SldVerde.Value = color.Green;
        SldAzul.Value = color.Blue;
        esAleatorio = false;

    }

    private async void imgBtn_presionado(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(ValorHex);
        var toast = Toast.Make("Color Copiado",
            CommunityToolkit.Maui.Core.ToastDuration.Short,
            12);
        await toast.Show();
    }
}

