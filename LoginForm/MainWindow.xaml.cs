using LoginForm.Models;
using LoginForm.Services;
using System.Windows;
using System.Windows.Media;

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager _userManager; 

        public MainWindow()
        {
            InitializeComponent();

            _userManager = new UserManager();
        }

        private void OnRegisterClicked(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Password;


            _userManager.Register(username, password);

            //usernameTextBox.Text = "";
            usernameTextBox.Clear(); //Maakt de tekstbox leeg
            passwordTextBox.Clear();
            usernameTextBox.Focus(); //verplaatst cursor naar usernameTextBox
        }

        private void OnLoginClicked(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration()
            {
                Username = usernameTextBox.Text,
                Password = passwordTextBox.Password,
            };

            if(_userManager.TryLogin(registration))
            {
                statusTextBlock.Text = "Login succesvol!";
                statusTextBlock.Foreground = Brushes.Green;
            }
            else
            {
                statusTextBlock.Text = "Ongeldige gebruikersnaam of wachtwoord.";
                statusTextBlock.Foreground = Brushes.Red;
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}