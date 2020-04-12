using LiteDB;
using MeusJogos.Services;
using Xamarin.Forms;

namespace MeusJogos.Helpers
{
    public static class DBHelper
    {
        private static LiteDatabase _dbConnection;        

        public static LiteDatabase DBConnection
        {
            get
            {
                if (_dbConnection == null)
                {
                    _dbConnection = new LiteDatabase(DependencyService.Get<IDBPathProvider>().GetDBPath());
                }
                return _dbConnection;
            }
        }
    }
}
