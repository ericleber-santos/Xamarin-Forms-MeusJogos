using System;
using System.Collections.Generic;
using System.Text;

namespace MeusJogos.Helpers
{
    public static class Util
    {
        public static string USUARIOLOGADO = string.Empty;

        public static DateTime? DataHora()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }
    }
}
