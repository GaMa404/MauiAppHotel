using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class Cadastro : ContentPage
{
	public Cadastro()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			if (entry_confirmar_senha.Text != entry_senha.Text)
			{
				await DisplayAlertAsync("Erro", "As senhas não coincidem.", "OK");
				return;
			}

			Usuario u = new()
			{
				Email = entry_email.Text,
				Senha = entry_senha.Text
			};

			App.lista_usuarios.Add(u);

            await Navigation.PushAsync(new Login());
		}
		catch (Exception ex)
		{
			await DisplayAlertAsync("Erro", ex.Message, "OK");
			return;
        }
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new Login());
    }
}