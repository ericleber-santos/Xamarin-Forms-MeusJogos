using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MeusJogos.Services;
using MeusJogos.Views;

namespace MeusJogos
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            //DependencyService.Get<ICoresNavegacaoService>()?.SetStatusBarColor(Color.Black);
            MainPage = new AppShell();
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
