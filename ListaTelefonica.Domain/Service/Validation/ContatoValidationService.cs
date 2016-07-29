using System;
using System.Collections.Generic;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Domain.Resource;
using ListaTelefonica.Domain.Utils;
using ListaTelefonica.Domain.Utils.UtilsEnum;

namespace ListaTelefonica.Domain.Service.Validation
{
    public class ContatoValidationService
    {
        public IList<Message> ValidateEntity(Contato contato)
        {
            IList<Message> messages = new List<Message>();

            if (String.IsNullOrWhiteSpace(contato.Nome))
            {
                messages.Add(new Message
                    (String.Format(MessageResource.CampoObrigatorio, "Nome")
                    , StatusMessageEnum.Error));
            }
            if (contato.Telefone == null)
            {
                messages.Add(new Message
                    (String.Format(MessageResource.CampoObrigatorio, "Telefone")
                    , StatusMessageEnum.Error));
            }
            else if (contato.Telefone.Operadora == null)
            {
                messages.Add(new Message
                    (String.Format(MessageResource.CampoObrigatorio, "Operadora")
                    , StatusMessageEnum.Error));
            }
            if (String.IsNullOrWhiteSpace(contato.Cor))
            {
                messages.Add(new Message
                    (String.Format(MessageResource.CampoObrigatorio, "Cor")
                    , StatusMessageEnum.Error));
            }
            if (contato.DataInclusao == default(DateTime))
            {
                messages.Add(new Message
                    (String.Format(MessageResource.CampoObrigatorio, "Data da inclusão")
                    , StatusMessageEnum.Error));
            }
            
            return messages;
        }

        public IList<Message> ValidateEntityDeletion(Contato contato, IContatoRepository repository)
        {
            IList<Message> messages = new List<Message>();                     

            return messages;
        }
    }
}
