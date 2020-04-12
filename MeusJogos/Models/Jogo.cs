using LiteDB;
using MeusJogos.Helpers;
using System;

namespace MeusJogos.Models
{
    public  class Jogo
    {
        [BsonId]
        public int JOG_ID { get; set; }
        public string JOG_APP_USUARIO { get; set; } = Util.USUARIOLOGADO;
        public string JOG_NOME { get; set; }
        public int JOG_CATEGORIACODIGO { get; set; }
        public string JOG_CATEGORIANOME { get; set; }        
        public string JOG_LOGIN { get; set; }       
        public string JOG_EMAILCADASTRADO { get; set; }
        public string JOG_PERSONAGEMPRINCIPAL { get; set; }
        public string JOG_BUILD { get; set; }
        public int JOG_NIVEL { get; set; }
        public string JOG_URLSITE { get; set; }
        public string JOG_URLBUILD { get; set; }
        public DateTime? JOG_CADASTRADO { get; set; }
        public DateTime? JOG_ULTIMAALTERACAO { get; set; } = Util.DataHora(); 
        public string JOG_USUALTERACAO { get; set; } = Util.USUARIOLOGADO;

        public Jogo()
        {


        }
    }
}
