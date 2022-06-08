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
    public partial class LastRecord : ContentPage
    {
        public LastRecord(string nameRecord)
        {
            InitializeComponent();
            recordValue.Text = nameRecord;
        }

        IFirebaseConfig firebaseConfig = new FirebaseConfig()
        {
            AuthSecret = "Uvj6hJqh0IVjXREWY4Qj3wyemLsVfaBChIy5655w",
            BasePath = "https://beauty-6b00d-default-rtdb.firebaseio.com/ "
        };

        private void Button_Clicked(object sender, EventArgs e)
        {
            bool canRecord = true;
            IFirebaseClient firebaseClient = new FireSharp.FirebaseClient(firebaseConfig);
            FirebaseResponse firebaseResponse = firebaseClient.Get(@"Records");
            Dictionary<string, UserRecord> data = JsonConvert.DeserializeObject<Dictionary<string, UserRecord>>(firebaseResponse.Body.ToString());
            List<UserRecord> userRecords = new List<UserRecord>();
            foreach (var item in userRecords)
            {
                if (item.NameRecord == recordValue.Text)
                {
                    userRecords.Add(item);
                }
            }
            foreach (var item in data)
            {
                if (int.Parse(LastTime.Text.Substring(14, 2)) + 1 != int.Parse(item.Value.TimeRecord.Substring(14, 2)) && int.Parse(LastTime.Text.Substring(14, 2)) + 2 != int.Parse(item.Value.TimeRecord.Substring(14, 2)) && int.Parse(LastTime.Text.Substring(14, 2)) - 1 != int.Parse(item.Value.TimeRecord.Substring(14, 2)) && int.Parse(LastTime.Text.Substring(14, 2)) - 2 != int.Parse(item.Value.TimeRecord.Substring(14, 2)) && int.Parse(LastTime.Text.Substring(14, 2)) != int.Parse(item.Value.TimeRecord.Substring(14, 2)))
                    canRecord = true;
                else
                    canRecord = false;
            }
            if (canRecord)
            {
                firebaseClient = new FireSharp.FirebaseClient(firebaseConfig);
                UserRecord userRecord = new UserRecord() { DataRecord = LastData.Text, TimeRecord = LastTime.Text, NameRecord = recordValue.Text};
                firebaseClient.Set("Records/" + LogIn.NameUser + data.Count.ToString(), userRecord);
                DisplayAlert("Great!", "Вы записаны.", "OK");
                endRecordValue.Text = recordValue.Text;
                StartRecord.IsVisible = false;
                EndRecord.IsVisible = true;
            }
            else
                DisplayAlert("Ошибка!","Запись не возможна","ОК");
        }

        private void DataStartRecord_DateSelected(object sender, DateChangedEventArgs e)
        {
            LastData.Text = "Дата записи: " + e.NewDate.ToString("dd/MM/yyyy");
        }

        private void TimeStartRecord_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            LastTime.Text = "Время записи: " + TimeStartRecord.Time.ToString();
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            Application.Current.MainPage = new Services();
            return true;
        }
    }
}