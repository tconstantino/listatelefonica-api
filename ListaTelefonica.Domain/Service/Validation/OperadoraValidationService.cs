using System;
using System.Collections.Generic;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Domain.Resource;
using ListaTelefonica.Domain.Utils;
using ListaTelefonica.Domain.Utils.UtilsEnum;

namespace ListaTelefonica.Domain.Service.Validation
{
    public class OperadoraValidationService
    {
        public IList<Message> ValidateEntity(Operadora operadora)        
        {
            IList<Message> messages = new List<Message>();

            if(operadora.Codigo == default(Int32))
            {
                messages.Add(new Message
                    (String.Format(MessageResource.CampoObrigatorio, "Código")
                    ,StatusMessageEnum.Error));
            }
            if (String.IsNullOrWhiteSpace(operadora.Nome))
            {
                messages.Add(new Message
                    (String.Format(MessageResource.CampoObrigatorio, "Nome")
                    , StatusMessageEnum.Error));
            }
            if (operadora.Categoria == null)
            {
                messages.Add(new Message
                    (String.Format(MessageResource.CampoObrigatorio, "Categoria")
                    , StatusMessageEnum.Error));
            }
            if (operadora.Preco == default(Decimal))
            {
                messages.Add(new Message
                    (String.Format(MessageResource.CampoObrigatorio, "Preço")
                    , StatusMessageEnum.Error));
            }

            return messages;
        }

        public IList<Message> ValidateEntityDeletion(Operadora operadora, IOperadoraRepository repository)
        {
            IList<Message> messages = new List<Message>();

            if(repository.OperadoraPossuiTelefones(operadora.Identificador))
            {
                messages.Add(new Message
                    (String.Format(MessageResource.PossuiDependentes, operadora.Nome, "telefones")
                    , StatusMessageEnum.Error));
            }

            return messages;
        }
    }
}
