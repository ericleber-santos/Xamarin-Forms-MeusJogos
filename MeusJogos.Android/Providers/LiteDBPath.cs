using MeusJogos.Droid.Providers;
using MeusJogos.Services;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(LiteDBPath))]
namespace MeusJogos.Droid.Providers
{   
    public class LiteDBPath : IDBPathProvider
    {
        public string GetDBPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "meusjogos.db3");
        }
    }
}