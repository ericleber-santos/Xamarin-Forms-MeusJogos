using MeusJogos.Services;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using MeusJogos.Droid.Providers;
using Plugin.CurrentActivity;

[assembly: Xamarin.Forms.Dependency(typeof(CoresNavegacao))]

namespace MeusJogos.Droid.Providers
{
    public class CoresNavegacao : ICoresNavegacaoService
    {
        public void SetStatusBarColor(Color color)
        {
            var atividade = CrossCurrentActivity.Current.Activity;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                atividade.Window.SetStatusBarColor(color.AddLuminosity(-0.1).ToAndroid());
            }
        }

        public void SetNavigationBarColor(Color color)
        {
            var atividade = CrossCurrentActivity.Current.Activity;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                atividade.Window.SetNavigationBarColor(color.ToAndroid());
            }
        }
    }
}