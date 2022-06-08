using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beauty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Record : ContentPage
    {
        public Record()
        {
            InitializeComponent();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            if (!popuplayout.IsVisible)
            {
                popuplayout.IsVisible = !popuplayout.IsVisible;
                popuplayout.AnchorX = 5;
                popuplayout.AnchorY = 5;
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

        private void Services(object sender, EventArgs e) => Application.Current.MainPage = new Services();

        private void Records(object sender, EventArgs e) => Application.Current.MainPage = new Record();

        private void AboutUs(object sender, EventArgs e) => Application.Current.MainPage = new AboutUs();

        private void RecordClick(object sender, EventArgs e)
        {
            Application.Current.MainPage = new zapispil();
        }
        private void RecordChistClick(object sender, EventArgs e)
        {
            Application.Current.MainPage = new zapischist();
        }
        private void RecordMaskClick(object sender, EventArgs e)
        {
            Application.Current.MainPage = new zapismask();
        }
        private void RecordDermaClick(object sender, EventArgs e)
        {
            Application.Current.MainPage = new zapisderma();
        }
        private void RecordMassClick(object sender, EventArgs e)
        {
            Application.Current.MainPage = new zapismass();
        }
        private void Button_Clicked(object sender, EventArgs e) => Application.Current.MainPage = new MyRecord();
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            Application.Current.MainPage = new Services();
            return true;
        }
    }
}