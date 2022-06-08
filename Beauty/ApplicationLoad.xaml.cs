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
    public partial class ApplicationLoad : ContentPage
    {
        public ApplicationLoad()
        {
            InitializeComponent();
        }

        private void LogIn(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LogIn();
        }

        private void SignIn(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Register();
        }
    }
}