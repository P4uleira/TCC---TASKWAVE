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

        public Mensagem(string conteudoMensagem, DateTime dataEnvioMensagem, int tarefaID)
        {
            ConteudoMensagem = conteudoMensagem;
            DataEnvioMensagem = dataEnvioMensagem;
            TarefaID = tarefaID;
        }
    }
}
