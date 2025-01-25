using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKWAVE.ENTITY.Model
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public DateTime DataCriacaoUsuario { get; set; }

        public Usuario()
        {
        }

        public Usuario(int idUsuario, string nomeUsuario, string emailUsuario, string senhaUsuario, DateTime dataCriacaoUsuario)
        {
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
            EmailUsuario = emailUsuario;
            SenhaUsuario = senhaUsuario;
            DataCriacaoUsuario = dataCriacaoUsuario;
        }
    }
}
