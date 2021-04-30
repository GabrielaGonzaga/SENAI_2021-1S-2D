using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Personagens = new HashSet<Personagen>();
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? idTipoUsuario { get; set; }

        public virtual TiposDeUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Personagen> Personagens { get; set; }
    }
}
