using MeusJogos.DAO;
using MeusJogos.Models;
using MeusJogos.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeusJogos.ViewModels
{
    public class MeusJogosViewModel : BaseViewModel
    {
        #region propriedades

        public ObservableCollection<Jogo> ListaJogos { get; private set; }
        public ICommand ItemSelectionChangedCommand => new Command(async () => await ItemSelectionChanged());                       

        private Jogo jogoeSelecionado;

        public Jogo JogoSelecionado
        {
            get
            {
                return jogoeSelecionado;
            }
            set
            {
                SetProperty(ref jogoeSelecionado, value);
                OnPropertyChanged(nameof(JogoSelecionado));
            }
        } 

        private decimal totalRegistros = 0;

        public decimal TOTAL_REGISTROS
        {
            get { return totalRegistros; }

            set
            {
                SetProperty(ref totalRegistros, value);               
            }
        }      

        #endregion

        public MeusJogosViewModel()
        { 
            ListaJogos = new ObservableCollection<Jogo>();
        }

        public void CarregarJogos()
        {
            if (IsBusy)
                return;

            IsBusy = true;
         
            TOTAL_REGISTROS = 0;

            try
            { 
                this.ListaJogos.Clear();                              

                foreach (var jogo in JogoDAO.ListarTodos())
                {
                    ListaJogos.Add(jogo);
                }
               
                TOTAL_REGISTROS = ListaJogos.Count();
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

        async Task ItemSelectionChanged()
        {
            if (jogoeSelecionado == null)
            {
                return;
            }
            else
            {
                try
                {
                    await Shell.Current.Navigation.PushModalAsync(new JogoDetalhePage(jogoeSelecionado), true);
                    JogoSelecionado = null;
                }
                catch (Exception e)
                {
                    Debug.Write(e);
                }
            }
        }

    }
}
