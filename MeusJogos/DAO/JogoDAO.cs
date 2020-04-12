using LiteDB;
using MeusJogos.Helpers;
using MeusJogos.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MeusJogos.DAO
{
    public class JogoDAO
    {
        readonly static LiteDatabase _db = DBHelper.DBConnection;               

        public static Jogo GetJogo(string jogoNome, string jogoLogin)
        {
            return _db.GetCollection<Jogo>("Jogos").FindOne(x => 
            x.JOG_APP_USUARIO.ToUpper().Trim() == Util.USUARIOLOGADO &&
            x.JOG_NOME.ToUpper().Trim() == jogoNome.ToUpper().Trim() &&
            x.JOG_LOGIN.ToUpper().Trim() == jogoLogin.ToUpper().Trim()
            );
        }

        public static bool Atualizar(Jogo jogo)
        {
            try
            {
                var jogos = _db.GetCollection<Jogo>("Jogos");                

                if (jogo.JOG_ID > 0)
                {
                    return jogos.Update(jogo);
                }
                else
                {
                    jogo.JOG_ID = jogos.Count() == 0 ? 1 : (int)(jogos.Max(x => x.JOG_ID) + 1);
                   
                    return jogos.Upsert(jogo);
                }
            }
            catch (LiteException e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }       
      
        public static List<Jogo> ListarTodos()
        {
            return _db.GetCollection<Jogo>("Jogos").FindAll().Where(x => x.JOG_APP_USUARIO.ToUpper().Trim() == Util.USUARIOLOGADO.ToUpper().Trim()).ToList();
        }

        public static bool Deletar(Jogo jogo)
        {
            return _db.GetCollection<Jogo>("Jogos").Delete(jogo.JOG_ID); 
        }

    }
}

   