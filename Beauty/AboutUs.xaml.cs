using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beauty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutUs : ContentPage
    {
        public AboutUs()
        {
            InitializeComponent();
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            if (!popuplayout.IsVisible)
            {
                popuplayout.IsVisible = !popuplayout.IsVisible;
                popuplayout.AnchorX = 10;
                popuplayout.AnchorY = 10;
                Animation scaleAnimation = new Animation(f => popuplayout.Scale = f, 0.5, 1, Easing.CubicIn);
                Animation fadeAnimation = new Animation(f => popuplayout.Opacity = f, 0.2, 1, Easing.CubicIn);
                scaleAnimation.Commit(popuplayout, "popupScaleAnimation", 250);
                fadeAnimation.Commit(popuplayout, "popupFadeAnimation", 250);
                setting.IsVisible = false;
            }
            
        }

        private async void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            if (popuplayout.IsVisible)
            {
                await Task.WhenAny<bool>(popuplayout.FadeTo(0, 200, Easing.CubicIn));
                popuplayout.IsVisible = !popuplayout.IsVisible;
                setting.IsVisible = true;
            }
        }

        private void Record(object sender, EventArgs e) => Application.Current.MainPage = new Record();

        private void Services(object sender, EventArgs e) => Application.Current.MainPage = new Services();

        private void AboutUss(object sender, EventArgs e) => Application.Current.MainPage = new AboutUs();
        private void Button_Clicked(object sender, EventArgs e) => Application.Current.MainPage = new MyRecord();
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            Application.Current.MainPage = new Services();
            return true;
        }
    }
}