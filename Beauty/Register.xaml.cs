using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beauty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }
        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ApplicationLoad();
        }

        IFirebaseConfig firebaseConfig = new FirebaseConfig()
        {
            AuthSecret = "Uvj6hJqh0IVjXREWY4Qj3wyemLsVfaBChIy5655w",
            BasePath = "https://beauty-6b00d-default-rtdb.firebaseio.com/ "
        };
        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (loginEntry.Text != null && passwordRepeat.Text == passwordEntry.Text)
                {
                    IFirebaseClient firebaseClient = new FireSharp.FirebaseClient(firebaseConfig);
                    User newUser = new User()
                    {
                        Login = loginEntry.Text,
                        Password = passwordEntry.Text
                    };
                    firebaseClient.Set("User/" + newUser.Login, newUser);
                    DisplayAlert("Great!", "Создание произошло успешно.", "OK");
                }
            }
            catch (AggregateException)
            {
                DisplayAlert("Ошибка!", "Нет подключения к интернету!", "OK");
            }
            catch (ArgumentNullException)
            {
                DisplayAlert("Ошибка!", "Вы ввели недостаточно информации.", "OK");
            }
            catch (FormatException)
            {
                DisplayAlert("Ошибка!", "Неправельный формат записи данный.", "OK");
            }
            catch (Exception)
            {
                DisplayAlert("Ошибка!", "Неизвестная ошибка, попробуйте еще раз и обратитесь к администратору. ", "OK");
            }
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            Application.Current.MainPage = new ApplicationLoad();
            return true;
        }
    }
}