using MeusJogos.DAO;
using MeusJogos.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeusJogos.ViewModels
{
    public class CadastroAcessoViewModel : BaseViewModel
    {
        #region propriedades

        public ICommand CadastrarCommand => new Command(async () => await Cadastrar(), () => !IsBusy);     

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                SetProperty(ref usuario, value);
            }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                SetProperty(ref senha, value);
            }
        }

        private string confirmarSenha;
        public string ConfirmarSenha
        {
            get { return confirmarSenha; }
            set
            {
                SetProperty(ref confirmarSenha, value);
            }
        }

        #endregion


        public CadastroAcessoViewModel()
        {
        }


        async Task Cadastrar()
        {
            if(IsBusy) return;

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

            if (string.IsNullOrEmpty(ConfirmarSenha))
            {
                await Shell.Current.DisplayAlert("CONFIRMAR SENHA", "Confirmação da Senha não foi informada!", "Ok");
                return;
            }

            if (ConfirmarSenha != Senha)
            {
                await Shell.Current.DisplayAlert("CONFIRMAR SENHA", "Senha e Confirmação da Senha devem ser iguais!", "Ok");
                return;
            }                     

            if(AcessoDAO.GetAcesso(Usuario) != null)
            {
                await Shell.Current.DisplayAlert("USUÁRIO", "Usuário ja esta em uso!", "Ok");
                return;
            }
            #endregion

            IsBusy = true;

            try
            {
                if (AcessoDAO.Cadastrar(new Acesso(){ ACE_USUARIO = Usuario, ACE_SENHA = BCrypt.Net.BCrypt.HashPassword(Senha, BCrypt.Net.BCrypt.GenerateSalt())}))
                {
                    await Shell.Current.DisplayAlert("SUCESSO", "Usuário cadastrado com sucesso!", "Ok");
                    await Shell.Current.Navigation.PopModalAsync();
                }
                else
                {
                    await Shell.Current.DisplayAlert("OPERAÇÃO CANCELADA", "Não foi possível cadastrar o usuário!", "Ok");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
