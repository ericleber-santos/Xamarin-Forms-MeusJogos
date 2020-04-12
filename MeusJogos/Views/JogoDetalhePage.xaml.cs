using MeusJogos.Models;
using MeusJogos.Services;
using MeusJogos.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeusJogos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JogoDetalhePage : ContentPage
    {
        readonly JogoDetalheViewModel _ViewModel;
        private Jogo _Jogo;

        public JogoDetalhePage()
        {
            InitializeComponent();
            this.BindingContext = _ViewModel = new JogoDetalheViewModel();
            btnExcluir.IsVisible = false;
            pancakeExcluir.IsVisible = false;
        }

        public JogoDetalhePage(Jogo jogo)
        {
            InitializeComponent();
            _Jogo = jogo;
            this.BindingContext = _ViewModel = new JogoDetalheViewModel(_Jogo);
            btnExcluir.IsVisible = true;
            pancakeExcluir.IsVisible = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ViewModel.PopularListaCategorias();
            _ViewModel.ExibirInformacoes();

            if (_ViewModel.CategoriaSelecionada != null && PickerCategorias.Items.Count > 0)
            {
                PickerCategorias.SelectedIndex = PickerCategorias.Items.IndexOf(_ViewModel.CategoriaSelecionada.CAT_NOME);
            }
        }      
    }
}