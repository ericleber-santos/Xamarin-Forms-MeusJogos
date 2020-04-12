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
    public partial class CadastroAcessoPage : ContentPage
    {
        readonly CadastroAcessoViewModel _ViewModel;
        public CadastroAcessoPage()
        {
            InitializeComponent();
            this.BindingContext = _ViewModel = new CadastroAcessoViewModel();
        }
    }
}