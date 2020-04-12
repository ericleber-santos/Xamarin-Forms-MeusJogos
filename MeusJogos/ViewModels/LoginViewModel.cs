using MeusJogos.DAO;
using MeusJogos.Helpers;
using MeusJogos.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MeusJogos.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        #region propriedades

        public ICommand LogarCommand => new Command(async () => await Logar(), () => !IsBusy);

        public ICommand CadastrarCommand => new Command(async () => await Cadastrar(), () => !IsBusy);

        private string usuario = string.Empty;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                SetProperty(ref usuario, value);
            }
        }

        private string senha = string.Empty;
        public string Senha
        {
            get { return senha; }
            set
            {
                SetProperty(ref senha, value);
            }
        }

        private string versaoApp = string.Empty;

        public string VersaoApp
        {
            get { return versaoApp; }
            set
            {
                SetProperty(ref versaoApp, value);              
            }
        }

        private bool primeiroAcesso;

        public bool PrimeiroAcesso
        {
            get { return primeiroAcesso; }
            set
            {
                SetProperty(ref primeiroAcesso, value);               
            }
        }

        #endregion

        #region construtores

        public LoginViewModel()
        {
            VersaoApp = VersionTracking.CurrentVersion;

            PrimeiroAcesso = AcessoDAO.EhPrimeiroACesso();

            this.Usuario = Preferences.Get("key_ultimoUsuario", string.Empty);
        }

        #endregion

        #region metodos

        private async Task Logar()
        {
            if (IsBusy) return;

            #region validação 
            if (string.IsNullOrEmpty(Usuario))
            {
                await Shell.Current.DisplayAlert("USUÁRIO", "Usuário não foi informado!", "Ok");
                return;
            }

            if (Usuario.Length < 4)
            {
                await Shell.Current.DisplayAlert("USUÁRIO", "Usuário deve conter no mínimo 4 caracteres!", "Ok");
                return;
            }

            if (Usuario == Senha)
            {
                await Shell.Current.DisplayAlert("SENHA", "Senha não pode ser igual ao Usuário!", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Senha))
            {
                await Shell.Current.DisplayAlert("SENHA", "Senha não foi informada!", "Ok");
                return;
            }

            if (Senha.Length < 6)
            {
                await Shell.Current.DisplayAlert("SENHA", "Senha deve conter no mínimo 6 caracteres!", "Ok");
                return;
            }

            if (Regex.Replace(Senha, "[a-zA-Z0-9]", "").Length == 0)
            {
                await Shell.Current.DisplayAlert("SENHA", "Senha deve conter no mínimo 1 caracter especial!", "Ok");
                return;
            }            
            #endregion

            IsBusy = true;
           
            var user = AcessoDAO.GetAcesso(Usuario);

            if (user != null && BCrypt.Net.BCrypt.Verify(Senha, user.ACE_SENHA))
            {                
                Util.USUARIOLOGADO = this.Usuario.ToString().Trim();
                Preferences.Set("key_ultimoUsuario", this.Usuario.ToString().Trim());
                await Shell.Current.GoToAsync("\\\\home\\inicio");
            }
            else
            {
                await Shell.Current.DisplayAlert("DADOS INCORRETOS", "Acesso não autorizado!", "Ok");
            }

            IsBusy = false;
        }

        private async Task Cadastrar()
        {
            if (IsBusy) return;           

            await Shell.Current.Navigation.PushModalAsync(new CadastroAcessoPage());   
        }


        #endregion
    }
}
