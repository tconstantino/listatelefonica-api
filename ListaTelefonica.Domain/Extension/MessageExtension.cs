using System;
using System.Collections.Generic;
using System.Linq;
using ListaTelefonica.Domain.Utils;
using ListaTelefonica.Domain.Utils.UtilsEnum;

namespace ListaTelefonica.Domain.Extension
{
    public static class MessageExtension
    {        
        public static Boolean HasInfo(this IList<Message> messages)
        {
            if (messages == null) throw new ArgumentNullException();

            return messages.Select(m => m.Status).Contains(StatusMessageEnum.Info);
        }

        public static Boolean HasSuccess(this IList<Message> messages)
        {
            if (messages == null) throw new ArgumentNullException();

            return messages.Select(m => m.Status).Contains(StatusMessageEnum.Success);
        }

        public static Boolean HasWarning(this IList<Message> messages)
        {
            if (messages == null) throw new ArgumentNullException();

            return messages.Select(m => m.Status).Contains(StatusMessageEnum.Warning);
        }

        public static Boolean HasError(this IList<Message> messages)
        {
            if (messages == null) throw new ArgumentNullException();

            return messages.Select(m => m.Status).Contains(StatusMessageEnum.Error);
        }
    }
}
