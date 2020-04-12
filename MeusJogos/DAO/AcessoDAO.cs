using LiteDB;
using MeusJogos.Helpers;
using MeusJogos.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MeusJogos.DAO
{
    public class AcessoDAO
    {
        readonly static LiteDatabase _db = DBHelper.DBConnection;

        public static bool EhPrimeiroACesso()
        {
            return _db.GetCollection<Acesso>("Acessos").Count() == 0;
        }      

        public static Acesso GetAcesso(string usuario)
        {
            return _db.GetCollection<Acesso>("Acessos").FindOne(x => x.ACE_USUARIO.ToUpper().Trim() == usuario.ToUpper().Trim());
        }

        public static bool Cadastrar(Acesso acesso)
        {
            try
            {
                if (acesso.ACE_ID == 0)
                {
                    var acessos = _db.GetCollection<Acesso>("Acessos");
                    acesso.ACE_ID = acessos.Count() == 0 ? 1 : (int)(acessos.Max(x => x.ACE_ID) + 1);
                    return acessos.Upsert(acesso);
                }
                else
                {
                    return false;
                }
            }
            catch (LiteException e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public static bool Atualizar(Acesso acesso)
        {
            try
            {
                var acessos = _db.GetCollection<Acesso>("Acessos");

                if (acesso.ACE_ID > 0)
                {
                    return acessos.Update(acesso);
                }
                else
                {
                    acesso.ACE_ID = acessos.Count() == 0 ? 1 : (int)(acessos.Max(x => x.ACE_ID) + 1);
                    return acessos.Upsert(acesso);
                }
            }
            catch (LiteException e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }       

    }
}
