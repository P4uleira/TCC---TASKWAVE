using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKWAVE.ENTITY.Model
{
    public class Mensagem
    {
        public int IdMensagem { get; set; }
        public string ConteudoMensagem { get; set; }
        public DateTime DataEnvioMensagem { get; set; }

        public Mensagem()
        {
        }

        public Mensagem(int idMensagem, string conteudoMensagem, DateTime dataEnvioMensagem)
        {
            IdMensagem = idMensagem;
            ConteudoMensagem = conteudoMensagem;
            DataEnvioMensagem = dataEnvioMensagem;
        }
    }
}
