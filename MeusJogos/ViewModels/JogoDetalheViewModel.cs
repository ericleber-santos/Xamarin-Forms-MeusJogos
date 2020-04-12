using MeusJogos.DAO;
using MeusJogos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeusJogos.ViewModels
{
    public class JogoDetalheViewModel : BaseViewModel
    {
        #region PROPRIEDADES
        public ICommand SalvarJogoCommand => new Command(async () => await SalvarJogo());               

        public ICommand ExcluirJogoCommand => new Command(async () => await ExcluirJogo());

        public ObservableCollection<Categoria> ListaCategorias { get; set; }

        private Categoria categoriaSelecionada;

        public Categoria CategoriaSelecionada
        {
            get
            {
                return categoriaSelecionada;
            }
            set
            {
                SetProperty(ref categoriaSelecionada, value);
            }
        }

        private Jogo _Jogo;

        private string jogoNome;

        public string JogoNome
        {
            get
            {
                return jogoNome;
            }
            set
            {
                SetProperty(ref jogoNome, value);               
            }
        }
      
        private string jogoLogin;

        public string JogoLogin
        {
            get
            {
                return jogoLogin;
            }
            set
            {
                SetProperty(ref jogoLogin, value);                
            }
        }

        private string jogoEmail;

        public string JogoEmail
        {
            get
            {
                return jogoEmail;
            }
            set
            {
                SetProperty(ref jogoEmail, value);               
            }
        }

        private string jogoPersonagem;

        public string JogoPersonagem
        {
            get
            {
                return jogoPersonagem;
            }
            set
            {
                SetProperty(ref jogoPersonagem, value);               
            }
        }

        private string jogoBuild;

        public string JogoBuild
        {
            get
            {
                return jogoBuild;
            }
            set
            {
                SetProperty(ref jogoBuild, value);
            }
        }

        private int jogoNivel;

        public int JogoNivel
        {
            get
            {
                return jogoNivel;
            }
            set
            {
                SetProperty(ref jogoNivel, value);
            }
        }

        private string jogoURLSite;

        public string JogoURLSite
        {
            get
            {
                return jogoURLSite;
            }
            set
            {
                SetProperty(ref jogoURLSite, value);
            }
        }

        private string jogoURLBuild;

        public string JogoURLBuild
        {
            get
            {
                return jogoURLBuild;
            }
            set
            {
                SetProperty(ref jogoURLBuild, value);
            }
        }

        private string jogoDataCadastro;

        public string JogoDataCadastro
        {
            get
            {
                return jogoDataCadastro;
            }
            set
            {
                SetProperty(ref jogoDataCadastro, value);
            }
        }

        private string jogoDataAlteracao;

        public string JogoDataAlteracao
        {
            get
            {
                return jogoDataAlteracao;
            }
            set
            {
                SetProperty(ref jogoDataAlteracao, value);
            }
        }

        #endregion

        #region construtores

        public JogoDetalheViewModel()
        {
            this.ListaCategorias = new ObservableCollection<Categoria>();
        }

        public JogoDetalheViewModel(Jogo jogo)
        {
            this._Jogo = jogo;
            this.ListaCategorias = new ObservableCollection<Categoria>();
        }

        #endregion

        #region MÉTODOS
        public void ExibirInformacoes()
        {
            if (_Jogo != null)
            {
                JogoNome = _Jogo.JOG_NOME.ToUpper().Trim();
                CategoriaSelecionada = ListaCategorias.Where(x => x.CAT_CODIGO == _Jogo.JOG_CATEGORIACODIGO).FirstOrDefault();
                JogoLogin = _Jogo.JOG_LOGIN;
                JogoEmail = _Jogo.JOG_EMAILCADASTRADO;
                JogoPersonagem = _Jogo.JOG_PERSONAGEMPRINCIPAL;
                JogoBuild = _Jogo.JOG_BUILD;
                JogoNivel = _Jogo.JOG_NIVEL;
                JogoURLSite = _Jogo.JOG_URLSITE;
                JogoURLBuild = _Jogo.JOG_URLBUILD;

            }
            else
            {  
                JogoNome = string.Empty;
                CategoriaSelecionada = null;
                JogoLogin = string.Empty;
                JogoEmail = string.Empty;
                JogoPersonagem = string.Empty;
                JogoBuild = string.Empty;
                JogoNivel = 0;
                JogoURLSite = string.Empty;
                JogoURLBuild = string.Empty;
            }
        }

        public void PopularListaCategorias()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                this.ListaCategorias.Clear();
              
                  var Categorias = new List<Categoria>()
                    {
                        new Categoria()
                        {
                            CAT_CODIGO = 0,
                            CAT_NOME = "Não definida"
                        },
                         new Categoria()
                        {
                            CAT_CODIGO = 1,
                            CAT_NOME = "MOBA"
                        },                        
                        new Categoria()
                        {
                            CAT_CODIGO = 2,
                            CAT_NOME = "Hack and slash"
                        },
                        new Categoria()
                        {
                            CAT_CODIGO = 3,
                            CAT_NOME = "MMORPG"
                        },                       
                        new Categoria()
                        {
                            CAT_CODIGO = 4,
                            CAT_NOME = "RTS"
                        },
                        new Categoria()
                        {
                            CAT_CODIGO = 5,
                            CAT_NOME = "Simulação"
                        },
                         new Categoria()
                        {
                            CAT_CODIGO = 6,
                            CAT_NOME = "Estratégia"
                        },
                        new Categoria()
                        {
                            CAT_CODIGO = 7,
                            CAT_NOME = "Outros"
                        }
                    };               

                foreach (var categoria in Categorias)
                {
                    ListaCategorias.Add(categoria);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task SalvarJogo()
        {
            if (IsBusy)
                return;                    

            if (string.IsNullOrEmpty(JogoNome))
            {
                await Application.Current.MainPage.DisplayAlert("FALTA INFORMAÇÃO OBRIGATÓRIA",
                   "Informe o nome do jogo!",
                   "Ok");               
                return;
            }

            if (string.IsNullOrEmpty(JogoLogin))
            {
                await Application.Current.MainPage.DisplayAlert("FALTA INFORMAÇÃO OBRIGATÓRIA",
                   "Informe o Usuário do jogo(Login)!Não cadastre a senha do jogo, somente o usuário usado para logar.",
                   "Ok");
                return;
            }

            if (this._Jogo == null)
            {
                if(JogoDAO.GetJogo(JogoNome, JogoLogin) != null)
                {
                    await Application.Current.MainPage.DisplayAlert("ATENÇÃO",
                    "Este Nome de Jogo ja esta cadastrado com esse Usuário do jogo!",
                    "Ok");
                    return;
                }
            }

            IsBusy = true;


            Jogo jogo = new Jogo()
            {
                JOG_ID = (_Jogo == null ? 0 : _Jogo.JOG_ID),
                JOG_NOME = JogoNome,
                JOG_CATEGORIACODIGO = (CategoriaSelecionada != null ? CategoriaSelecionada.CAT_CODIGO : 0),
                JOG_CATEGORIANOME = (CategoriaSelecionada != null ? CategoriaSelecionada.CAT_NOME : string.Empty),
                JOG_LOGIN = JogoLogin,
                JOG_EMAILCADASTRADO = JogoEmail,
                JOG_PERSONAGEMPRINCIPAL = JogoPersonagem,
                JOG_BUILD = JogoBuild,
                JOG_NIVEL = JogoNivel,
                JOG_URLSITE = JogoURLSite,
                JOG_URLBUILD = JogoURLBuild               
            };
         
            try
            {
                if (JogoDAO.Atualizar(jogo))
                {
                    await Application.Current.MainPage.DisplayAlert("SUCESSO",
                       "Jogo cadastrado com sucesso!",
                       "Ok");

                    await Shell.Current.Navigation.PopModalAsync();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("ATENÇÃO",
                      "Não foi possível cadastrar o Jogo!",
                      "Ok");
                }
            }
            catch (Exception e)
            {
                Debug.Write(e);                
            }

            IsBusy = false;

        }

        async Task ExcluirJogo()
        {
            if (IsBusy || _Jogo == null) return;

            IsBusy = true;             

            try
            {
                if (JogoDAO.Deletar(_Jogo))
                {
                    await Application.Current.MainPage.DisplayAlert("SUCESSO",
                       "Jogo excluído com sucesso!",
                       "Ok");

                    await Shell.Current.Navigation.PopModalAsync();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("ATENÇÃO",
                      "Não foi possível excluir o Jogo!",
                      "Ok");
                }
            }
            catch (Exception e)
            {
                Debug.Write(e);                
            }

            IsBusy = false;
        }

        #endregion


    }
}
