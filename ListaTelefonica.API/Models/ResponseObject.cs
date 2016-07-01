using System;
using System.Collections.Generic;
using ListaTelefonica.Domain.Utils;

namespace ListaTelefonica.API.Models
{
    public class ResponseObject
    {
        public ResponseObject(IList<Message> mensagens, Object obj = null, String localizacao = null)
        {
            if (mensagens == null) throw new ArgumentNullException("Mensagens não pode ser nulo.");

            Mensagens = mensagens;
            Objeto = obj;
            Localizacao = localizacao;
        }

        public IList<Message> Mensagens { get; set; }
        public Object Objeto { get; set; }
        public String Localizacao { get; set; }
    }
}