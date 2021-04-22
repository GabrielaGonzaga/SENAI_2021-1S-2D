using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domains
{
    public class EstudioDomain
    {
        public int idEstudio { get; set; }

        //[Required(ErrorMessage = "Esse campo não pode ficar vazio")]
        public string nomeEstudio { get; set; }

    }
}
