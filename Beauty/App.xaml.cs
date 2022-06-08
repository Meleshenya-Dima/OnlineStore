using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Comfortaa-VariableFont_wght", Alias = "Comfortaa")]
namespace Beauty
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ApplicationLoad();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
