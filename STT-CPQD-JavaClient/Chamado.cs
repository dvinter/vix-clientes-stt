using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STT_CPQD_JavaClient
{
    class Chamado
    {
        public int Formulario { get; set; }
        public Conjuntos Conjuntos { get; set; }


    }


    class Conjuntos
    {

        public DadosBasicos DadosBasicos { get; set; }
        public Papeis Papeis { get; set; }



    }

    class DadosBasicos
    {
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public string DescricaoOrigem { get; set; }
        public int Atividade { get; set; }


    }

    class Papeis
    {

        public ANTE ANTE { get; set; }

    }

    class ANTE
    {

        public int idParticipante { get; set; }
        public int idTipoPapel { get; set; }

    }

}
