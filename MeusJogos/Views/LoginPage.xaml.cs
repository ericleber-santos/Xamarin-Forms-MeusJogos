using MeusJogos.Animations;
using MeusJogos.DAO;
using MeusJogos.Services;
using MeusJogos.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeusJogos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {       
        readonly LoginViewModel _ViewModel;

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = _ViewModel = new LoginViewModel();
        }

        #region Overrides

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(async () =>
            {
                await ViewAnimations.FadeAnimY(Foto);
                await ViewAnimations.FadeAnimY(Titulo);
                await ViewAnimations.FadeAnimY(stackLogin);
                await ViewAnimations.FadeAnimY(pancakeLogin);
                await ViewAnimations.FadeAnimY(btnLogin);
                await ViewAnimations.FadeAnimY(pancakeCadastro);
                await ViewAnimations.FadeAnimY(btnCadastro);
                await ViewAnimations.FadeAnimY(Icones);
            });

            _ViewModel.PrimeiroAcesso = AcessoDAO.EhPrimeiroACesso();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();            
        }

        #endregion

    }
}