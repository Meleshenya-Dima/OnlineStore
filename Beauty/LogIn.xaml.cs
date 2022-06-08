using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
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
    public partial class LogIn : ContentPage
    {
        public static string NameUser { get; set; }
        public LogIn()
        {
            InitializeComponent();
        }

        IFirebaseConfig firebaseConfig = new FirebaseConfig()
        {
            AuthSecret = "Uvj6hJqh0IVjXREWY4Qj3wyemLsVfaBChIy5655w",
            BasePath = "https://beauty-6b00d-default-rtdb.firebaseio.com/ "
        };

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new ApplicationLoad();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int count = 0;
            IFirebaseClient firebaseClient = new FireSharp.FirebaseClient(firebaseConfig);
            FirebaseResponse firebaseResponse = firebaseClient.Get(@"User/");
            Dictionary<string, User> data = JsonConvert.DeserializeObject<Dictionary<string, User>>(firebaseResponse.Body.ToString());
            foreach (var item in data)
            {
                if (item.Value.Password == passwordEntry.Text && item.Value.Login == loginEntry.Text)
                {
                    count++;
                    NameUser = loginEntry.Text;
                    Application.Current.MainPage = new Services();
                }
            }
            if (count == 0)
                DisplayAlert("Внимание.", "Нет такого пользователя. Зарегистрируйся!", "ОК");
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            Application.Current.MainPage = new ApplicationLoad();
            return true;
        }
    }
}