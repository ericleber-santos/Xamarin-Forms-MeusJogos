using MeusJogos.Services;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MeusJogos
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            DependencyService.Get<ICoresNavegacaoService>()?.SetStatusBarColor(Color.Black);
        }
    }
}
