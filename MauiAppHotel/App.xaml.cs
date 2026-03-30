using MauiAppHotel.Models;

namespace MauiAppHotel
{
    public partial class App : Application
    {
        public static List<Usuario> lista_usuarios = [];

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window w = new(new AppShell())
            {
                Height = 600,
                Width = 300
            };

            return w;
        }
    }
}