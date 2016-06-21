using System;
using System.Collections.Generic;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Domain.Resource;
using ListaTelefonica.Domain.Utils;
using ListaTelefonica.Domain.Utils.UtilsEnum;

namespace ListaTelefonica.Domain.Service.Validation
{
    class TelefoneValidationService
    {
        public IList<Message> ValidateEntity(Telefone entity)
        {
            IList<Message> messages = new List<Message>();

            if (entity.Numero == default(Int64))
            {
                messages.Add(new Message
                    (String.Format(MessageResource.CampoObrigatorio, "Número")
                    , StatusMessageEnum.Error));
            }
            if(entity.Operadora == null)
            {
                messages.Add(new Message
                    (String.Format(MessageResource.CampoObrigatorio, "Operadora")
                    , StatusMessageEnum.Error));
            }

            return messages;
        }

        public IList<Message> ValidateEntityDeletion(Telefone entity, ITelefoneRepository repository)
        {
            IList<Message> messages = new List<Message>();

            if (repository.TelefonePossuiContato(entity.Identificador))
            {
                messages.Add(new Message
                    (String.Format(MessageResource.PossuiDependentes, "Telefone " + entity.Numero, "Contato")
                    , StatusMessageEnum.Error));
            }

            return messages;
        }        
    }
}
