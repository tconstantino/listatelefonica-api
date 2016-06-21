using System;
using ListaTelefonica.Domain.Utils.UtilsEnum;

namespace ListaTelefonica.Domain.Utils
{
    public class Message
    {
        public Message(String descricao, StatusMessageEnum status)
        {
            Descricao = descricao;
            Status = status;
        }

        public String Descricao { get; set; }
        public StatusMessageEnum Status { get; set; }
    }
}
