using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    public async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			Usuario u = new()
			{
				Email = entry_email.Text,
				Senha = entry_senha.Text
			};

			// LINQ
			bool usuarioCadastrado = App.lista_usuarios.Any(i => (i.Email == u.Email && i.Senha == u.Senha));

			if (usuarioCadastrado)
			{
				await SecureStorage.Default.SetAsync("email", u.Email);
				await Navigation.PushAsync(new ContratacaoHospedagem());
			}
			else
			{
				await DisplayAlertAsync("Erro", "Email ou senha incorretos.", "OK");
				return;
            }
        }
		catch(Exception ex)
		{
			await DisplayAlertAsync("Error", ex.Message, "OK");
			return;
        }
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new Cadastro());
    }
}