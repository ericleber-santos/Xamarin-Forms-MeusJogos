using MeusJogos.Services;
using MeusJogos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeusJogos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeusJogosPage : ContentPage
    {
        readonly MeusJogosViewModel _ViewModel;

        public MeusJogosPage()
        {
            InitializeComponent();
            this.BindingContext = _ViewModel = new MeusJogosViewModel();          
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ViewModel.CarregarJogos();           
        }       

        async void AddJogo_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushModalAsync(new JogoDetalhePage(), true);            
        }
    }
}