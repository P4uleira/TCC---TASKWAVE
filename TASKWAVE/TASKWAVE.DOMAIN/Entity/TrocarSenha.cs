using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKWAVE.DOMAIN.ENTITY
{
    public class TrocaSenhaDTO
    {
        public string Token { get; set; }
        public string NovaSenha { get; set; }
        public string ConfirmarSenha { get; set; }
    }
}
