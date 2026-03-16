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

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void dtpck_checkout_DateSelected(object sender, DateChangedEventArgs e)
    {

    }
}