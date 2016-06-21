using System;
using System.Collections.Generic;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Domain.Resource;
using ListaTelefonica.Domain.Utils;
using ListaTelefonica.Domain.Utils.UtilsEnum;

namespace ListaTelefonica.Domain.Service.Validation
{
    public class CategoriaValidationService
    {
        public IList<Message> ValidateEntity(Categoria categoria)
        {
            IList<Message> messages = new List<Message>();

            if (String.IsNullOrWhiteSpace(categoria.Nome))
            {
                messages.Add(new Message
                    (String.Format(MessageResource.CampoObrigatorio, "Nome")
                    , StatusMessageEnum.Error));
            }

            return messages;
        }

        public IList<Message> ValidateEntityDeletion(Categoria categoria, ICategoriaRepository repository)
        {
            IList<Message> messages = new List<Message>();

            if (repository.CategoriaPossuiOperadoras(categoria.Identificador))
            {
                messages.Add(new Message
                   (String.Format(MessageResource.PossuiDependentes, categoria.Nome, "operadoras")
                   ,StatusMessageEnum.Error));
            }

            return messages;
        }
    }
}
