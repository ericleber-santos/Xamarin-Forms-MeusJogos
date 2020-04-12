using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeusJogos.Models
{   
    public class Acesso
    {
        [BsonId]
        public int ACE_ID { get; set; }
        public string ACE_USUARIO { get; set; }
        public string ACE_SENHA { get; set; }

        public Acesso()
        {
           

        }
    }
}
