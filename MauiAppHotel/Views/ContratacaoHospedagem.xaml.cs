using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    List<Quarto> lista_quartos = new()
    {
        new Quarto()
        {
            Descricao = "Suíte Super Luxo",
            ValorDiariaAdulto = 110,
            ValorDiariaCrianca = 55
        },
        new Quarto()
        {
            Descricao = "Suíte Luxo",
            ValorDiariaAdulto = 80,
            ValorDiariaCrianca = 40
        },
        new Quarto()
        {
            Descricao = "Suíte Simples",
            ValorDiariaAdulto = 50,
            ValorDiariaCrianca = 25
        },
        new Quarto()
        {
            Descricao = "Suíte Crise",
            ValorDiariaAdulto = 25,
            ValorDiariaCrianca = 12.5
        }
    };

	public ContratacaoHospedagem()
	{
		InitializeComponent();

        // Abastecendo o picker com a lista de quartos
        pck_quarto.ItemsSource = lista_quartos;

        // Validando a data mínima e máxima do check-in
        dtpck_checkin.MinimumDate = DateTime.Today;
        dtpck_checkin.MaximumDate = DateTime.Today.AddMonths(2);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.Value.AddMonths(2);
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = (DatePicker)sender;

        DateTime data_selecionada = elemento.Date.Value;

        dtpck_checkin.MinimumDate = data_selecionada.AddDays(1);
        dtpck_checkin.MaximumDate = data_selecionada.AddMonths(2);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Montagem do objeto com os dados da hospedagem
            Hospedagem h = new()
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                DataCheckIn = (DateTime) dtpck_checkin.Date,
                DataCheckOut = (DateTime) dtpck_checkout.Date,
                QntAdultos = Convert.ToInt16(stp_adultos.Value),
                QntCriancas = Convert.ToInt16(stp_criancas.Value),
            };

            // Criação da nova tela, onde serão mostrados os dados de hospedagem
            // Juntando o esqueleto da tela com os dados da hospedagem
            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h
            });
        }
        catch(Exception ex)
        {
            await DisplayAlertAsync("Erro", ex.Message, "OK");
        }
    }

    protected override async void OnAppearing()
    {
        txt_usuario_logado.Text = await SecureStorage.Default.GetAsync("email");
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login());
    }
}