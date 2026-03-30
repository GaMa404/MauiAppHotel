namespace MauiAppHotel.Models
{
    public class Usuario
    {
        string _email = String.Empty;

        public string Email { 
            get => _email;
            set {
                if (value == null) throw new Exception("Digite o email");
            }
        }
        public string Senha { get; set; } = String.Empty;
    }
}
