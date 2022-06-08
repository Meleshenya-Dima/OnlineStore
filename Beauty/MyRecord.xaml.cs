using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beauty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyRecord : ContentPage
    {
        IFirebaseConfig firebaseConfig = new FirebaseConfig()
        {
            AuthSecret = "Uvj6hJqh0IVjXREWY4Qj3wyemLsVfaBChIy5655w",
            BasePath = "https://beauty-6b00d-default-rtdb.firebaseio.com/ "
        };

        public MyRecord()
        {
            InitializeComponent();
            IFirebaseClient firebaseClient = new FireSharp.FirebaseClient(firebaseConfig);
            FirebaseResponse firebaseResponse = firebaseClient.Get(@"Records");
            Dictionary<string, UserRecord> data = JsonConvert.DeserializeObject<Dictionary<string, UserRecord>>(firebaseResponse.Body.ToString());
            List<string> MainData = new List<string>();
            foreach (var item in data)
            {
                if (item.Key.Length >= LogIn.NameUser.Length)
                {
                    if (item.Key.Substring(0, LogIn.NameUser.Length) == LogIn.NameUser)
                    {
                        MainData.Add(item.Value.NameRecord);
                        MainData.Add(item.Value.DataRecord);
                        MainData.Add(item.Value.TimeRecord);
                        MainData.Add("");
                    }

                }
            }
            CollectionView collectionView = new CollectionView()
            {
                BackgroundColor = Color.White,
                ItemsSource = MainData
            };
            stackLayout.Children.Add(collectionView);
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            Application.Current.MainPage = new Services();
            return true;
        }
    }
}