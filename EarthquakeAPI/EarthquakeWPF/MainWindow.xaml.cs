using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;


namespace EarthquakeWPF
{
    public partial class MainWindow : Window
    {
        public string code = "";

        public MainWindow()
        {
            InitializeComponent();
            Logout.Visibility = Visibility.Collapsed;
        }

        private string PasswordGenerate(int length)
        {
            Random _random = new Random(Environment.TickCount);

            string chars = "0123456789";
            StringBuilder builder = new StringBuilder(length);

            for (int i = 0; i < length; ++i)
                builder.Append(chars[_random.Next(chars.Length)]);

            return builder.ToString();
        }

        private void CodeSender(string number, string randNumber)
        {
            const string accountSid = "AC46d729f9bab280d217192471bb510f0e";
            const string authToken = "9a4d673663e8e6de021d0c5d8c0af348";

            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(
            body: "Your confirmation code is " + randNumber,
            from: new Twilio.Types.PhoneNumber("+19413000318"),
            to: new Twilio.Types.PhoneNumber(number)
            );

            code = randNumber;
        }

        private void PasswordSender(string number, string password)
        {
            const string accountSid = "AC46d729f9bab280d217192471bb510f0e";
            const string authToken = "9a4d673663e8e6de021d0c5d8c0af348";

            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(
            body: "DONT SHOW THIS MESSAGE TO ANYONE! Your password is " + password,
            from: new Twilio.Types.PhoneNumber("+19413000318"),
            to: new Twilio.Types.PhoneNumber(number)
            );
        }

        private void ButtonOpenMenuClick(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenuClick(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void CloseLoginPanel(object sender, RoutedEventArgs e)
        {
            LoginForm.Visibility = Visibility.Collapsed;
        }

        private void OpenLoginPanel(object sender, RoutedEventArgs e)
        {
            Cart.Visibility = Visibility.Collapsed;
            RegistrateForm.Visibility = Visibility.Collapsed;
            LoginForm.Visibility = Visibility.Visible;
            if (RegistrateForm.Visibility == Visibility.Visible) RegistrateForm.Visibility = Visibility.Collapsed;
        }

        private void CloseRegistratePanel(object sender, RoutedEventArgs e)
        {
            RegistrateForm.Visibility = Visibility.Collapsed;
        }

        private void OpenRegistratePanel(object sender, RoutedEventArgs e)
        {
            Cart.Visibility = Visibility.Collapsed;
            LoginForm.Visibility = Visibility.Collapsed;
            RegistrateForm.Visibility = Visibility.Visible;
            if (LoginForm.Visibility == Visibility.Visible) LoginForm.Visibility = Visibility.Collapsed;
        }

        private void LoginUser(object sender, RoutedEventArgs e)
        {
            using (var context = new EarthquakeContext())
            {
                var users = context.Clients.Where(client => client.Login == UserLogin.Text.ToString() && client.Password == UserPassword.Password.ToString()).ToList();
                if (!users.Any())
                {
                    MessageBox.Show("Направильно введен логин или пароль");
                }
                else
                {
                    LoginIfLogged.Text = users[0].Name;

                    CloseLoginPanel(sender, e);

                    Registrate.Visibility = Visibility.Collapsed;
                    Login.Visibility = Visibility.Collapsed;
                    Logout.Visibility = Visibility.Visible;

                    UserLogin.Text = "";
                    UserPassword.Password = "";
                    CurrentClientId.Text = users[0].Id.ToString();
                }
            }
        }

        private void LogOutUser(object sender, RoutedEventArgs e)
        {

            Registrate.Visibility = Visibility.Visible;
            Login.Visibility = Visibility.Visible;
            Logout.Visibility = Visibility.Collapsed;

            LoginIfLogged.Text = "";
            UserLogin.Text = "";
            UserPassword.Password = "";
            CurrentClientId.Text = "-1";

        }

        private void RegistrateUser(object sender, RoutedEventArgs e)
        {
            using (var context = new EarthquakeContext())
            {
                var users = context.Clients.Where(client => client.Login == ClientLoginRegistrate.Text.ToString());
                if (users.Count() > 0)
                {
                    MessageBox.Show("Пользователь с такими логином уже зарегестрирован!");
                    return;
                }
                else if (ClientFullNameRegistrate.Text.ToString() == "")
                {
                    MessageBox.Show("Не заполнено поле ФИО");
                    return;
                }
                else if (ClientLoginRegistrate.Text.ToString() == "")
                {
                    MessageBox.Show("Не заполнено поле Логин");
                    return;
                }
                else if ((ClientPasswordRegistrate.Password.ToString() != ClientPasswordConfirm.Password.ToString()) || (ClientPasswordRegistrate.Password.ToString() == ""))
                {
                    MessageBox.Show("Пароли не совпадают");
                    return;
                }
                else if (ClientNumberRegistrate.Text.ToString() == "" || Regex.IsMatch(ClientNumberRegistrate.Text.ToString(), ".*?[a-zA-Z].*?"))
                {
                    MessageBox.Show("Неправильно заполнено поле Номер телефона");
                    return;
                }
                else
                {
                    try
                    {
                        var number = PasswordGenerate(4);
                        CodeSender(ClientNumberRegistrate.Text.ToString(), number);
                    }
                    catch (TwilioException error)
                    {
                        MessageBox.Show("Неправильный формат строки ");
                        return;
                    }

                    CloseRegistratePanel(sender, e);

                    RegistrateFormConfirm.Visibility = Visibility.Visible;
                }
            }
        }

        private void RegisterUserConfirm(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                using (var context = new EarthquakeContext())
                {
                    if (ClientRegisterConfirm.Text.ToString() == code)
                    {
                        var clients = context.Set<Client>();
                        clients.Add(new Client
                        {
                            Name = ClientFullNameRegistrate.Text.ToString(),
                            Login = ClientLoginRegistrate.Text.ToString(),
                            Password = ClientPasswordRegistrate.Password.ToString(),
                            Phone = ClientNumberRegistrate.Text.ToString(),
                            Rights = Rights.Client
                        });
                        context.SaveChanges();

                        ClientNumberRegistrate.Text = "+";
                        ClientLoginRegistrate.Text = "";
                        ClientPasswordRegistrate.Password = "";
                        ClientPasswordConfirm.Password = "";
                        ClientFullNameRegistrate.Text = "";

                        RegistrateFormConfirm.Visibility = Visibility.Collapsed;
                        CurrentClientId.Text = clients.ToList()[clients.Count() - 1].Id.ToString();
                        break;
                    }
                    else
                        continue;
                }
            }
        }

        private void SendCodeMessage(object sender, RoutedEventArgs e)
        {
            var number = PasswordGenerate(4);
            CodeSender(ClientNumberRegistrate.Text.ToString(), number);
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void HideWindow(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Minimized;
            else if (WindowState == WindowState.Minimized)
                WindowState = WindowState.Normal;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ForgotPassword(object sender, RoutedEventArgs e)
        {
            LoginForm.Visibility = Visibility.Collapsed;
            ForgotPasswordWindow.Visibility = Visibility.Visible;
        }

        private void ForgotPasswordConfirm(object sender, RoutedEventArgs e)
        {
            var login = ForgotPasswordTextBox.Text;
            using (EarthquakeContext context = new EarthquakeContext())
            {
                var clientForgotPassword = context.Clients.Where(client => client.Login == login).ToList()[0];
                var password = clientForgotPassword.Password;
                var phoneNumber = clientForgotPassword.Phone;
                try
                {
                    PasswordSender(phoneNumber, password);
                }
                catch(TwilioException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ForgotPasswordTextBox.Text = "";
                ForgotPasswordWindow.Visibility = Visibility.Collapsed;
            }
        }

    }
}

