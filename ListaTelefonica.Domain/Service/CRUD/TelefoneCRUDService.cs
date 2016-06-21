using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Extension;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Domain.Resource;
using ListaTelefonica.Domain.Service.Validation;
using ListaTelefonica.Domain.Utils;
using ListaTelefonica.Domain.Utils.UtilsEnum;

namespace ListaTelefonica.Domain.Service.CRUD
{
    public class TelefoneCRUDService : CRUDService<Telefone>
    {
        public override IList<Message> Inserir(Telefone entity, IRepository<Telefone> repository, IContextoDB contextoDB)
        {
            TelefoneValidationService validation = new TelefoneValidationService();
            IList<Message> messages = validation.ValidateEntity(entity);

            if (messages.HasError()) return messages;

            try
            {
                contextoDB.IniciarTransacao();

                repository.Inserir(entity);

                contextoDB.Commit();

                messages.Add(new Message
                    (MessageResource.SucessoNaOperacao
                    , StatusMessageEnum.Success));
            }
            catch (Exception ex)
            {
                contextoDB.Rollback();

                messages.Add
                    (new Message
                    (String.Format(MessageResource.ErroOcorrido, ex.Message)
                    , StatusMessageEnum.Error));
            }

            return messages;
        }

        public override IList<Message> Atualizar(Telefone entity, IRepository<Telefone> repository, IContextoDB contextoDB)
        {
            TelefoneValidationService validation = new TelefoneValidationService();
            IList<Message> messages = validation.ValidateEntity(entity);

            if (messages.HasError()) return messages;

            try
            {
                contextoDB.IniciarTransacao();

                repository.Atualizar(entity);

                contextoDB.Commit();

                messages.Add(new Message
                    (MessageResource.SucessoNaOperacao
                    , StatusMessageEnum.Success));
            }
            catch (Exception ex)
            {
                contextoDB.Rollback();

                messages.Add
                    (new Message
                    (String.Format(MessageResource.ErroOcorrido, ex.Message)
                    , StatusMessageEnum.Error));
            }

            return messages;
        }

        public override IList<Message> Excluir(Telefone entity, IRepository<Telefone> repository, IContextoDB contextoDB)
        {
            TelefoneValidationService validation = new TelefoneValidationService();
            IList<Message> messages = validation.ValidateEntityDeletion(entity, (ICategoriaRepository)repository);

            if (messages.HasError()) return messages;

            try
            {
                contextoDB.IniciarTransacao();

                repository.Excluir(entity);

                contextoDB.Commit();

                messages.Add(new Message
                    (MessageResource.SucessoNaOperacao
                    , StatusMessageEnum.Success));
            }
            catch (Exception ex)
            {
                contextoDB.Rollback();

                messages.Add(new Message
                    (String.Format(MessageResource.ErroOcorrido, ex.Message)
                    , StatusMessageEnum.Error));
            }

            return messages;
        }
    }
}
