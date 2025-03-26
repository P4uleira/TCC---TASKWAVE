namespace TASKWAVE.DOMAIN.ENTITY
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

        public Mensagem(string messageContent, DateTime messageSentDate, int taskId)
        {
            ConteudoMensagem = messageContent;
            DataEnvioMensagem = messageSentDate;
            TarefaID = taskId;
        }
    }
}
