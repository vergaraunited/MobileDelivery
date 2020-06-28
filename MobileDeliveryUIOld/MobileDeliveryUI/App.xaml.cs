using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileDeliveryUI
{
    public partial class App : Application
    {
         public App()
        {            
            base.OnStart();
            InitializeComponent();
            MainPage = new MainPage();
        }

        private readonly Func<Stream, string, Task<bool>> saveSignatureDelegate;

        public App(Func<Stream, string, Task<bool>> saveSignature)
        {
            InitializeComponent();

            saveSignatureDelegate = saveSignature;

            MainPage = new NavigationPage(new MainPage());
        }

        public static Task<bool> SaveSignature(Stream bitmap, string filename)
        {
            return ((App)Application.Current).saveSignatureDelegate(bitmap, filename);
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
