using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKWAVE.API.Infrastructure.Model
{
    public class Mensagem
    {
        public int IdMensagem { get; set; }
        public string ConteudoMensagem { get; set; }
        public DateTime DataEnvioMensagem { get; set; }
        public int TarefaID { get; set; }
        public Tarefa Tarefa { get; set; }
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
