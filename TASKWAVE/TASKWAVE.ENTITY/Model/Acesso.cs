using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKWAVE.ENTITY.Model
{
    public class Acesso
    {
        public int IdAcesso { get; set; }
        public string NomeAcesso { get; set; }
        public string? DescricaoDescricao { get; set; }
        public DateTime DataCriacaoAcesso { get; set; }

        public Acesso()
        {
        }

        public Acesso(int idAcesso, string nomeAcesso, string? descricaoDescricao, DateTime dataCriacaoAcesso)
        {
            IdAcesso = idAcesso;
            NomeAcesso = nomeAcesso;
            DescricaoDescricao = descricaoDescricao;
            DataCriacaoAcesso = dataCriacaoAcesso;
        }
    }
}
