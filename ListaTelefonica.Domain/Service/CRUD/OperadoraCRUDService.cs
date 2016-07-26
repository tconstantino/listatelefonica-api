using System;
using System.Collections.Generic;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Extension;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Domain.Resource;
using ListaTelefonica.Domain.Service.Validation;
using ListaTelefonica.Domain.Utils;
using ListaTelefonica.Domain.Utils.UtilsEnum;

namespace ListaTelefonica.Domain.Service.CRUD
{
    public class OperadoraCRUDService : CRUDService<Operadora>
    {
        public override IList<Message> Inserir(Operadora entity, IRepository<Operadora> repository, IContextoDB contextoDB)
        {
            OperadoraValidationService validation = new OperadoraValidationService();
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
                    ,StatusMessageEnum.Error));
            }

            return messages;
        }

        public override IList<Message> Atualizar(Operadora entity, IRepository<Operadora> repository, IContextoDB contextoDB)
        {
            OperadoraValidationService validation = new OperadoraValidationService();
            IList<Message> messages = validation.ValidateEntity(entity);

            if (messages.HasError()) return messages;

            try
            {
                contextoDB.IniciarTransacao();

                repository.Atualizar(entity);

                contextoDB.Commit();

                messages.Add
                   (new Message
                   (MessageResource.SucessoNaOperacao
                   ,StatusMessageEnum.Error));
            }
            catch (Exception ex)
            {
                contextoDB.Rollback();

                messages.Add
                   (new Message
                   (String.Format(MessageResource.ErroOcorrido, ex.Message),
                   StatusMessageEnum.Error));
            }

            return messages;
        }

        public override IList<Message> Excluir(Operadora entity, IRepository<Operadora> repository, IContextoDB contextoDB)
        {
            OperadoraValidationService validation = new OperadoraValidationService();
            IList<Message> messages = validation.ValidateEntityDeletion(entity, (IOperadoraRepository)repository);

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

                messages.Add
                    (new Message
                    (String.Format(MessageResource.ErroOcorrido, ex.Message)
                    , StatusMessageEnum.Error));
            }

            return messages;
        }

        public IList<Message> Excluir(IList<Operadora> entities, IRepository<Operadora> repository, IContextoDB contextoDB)
        {
            OperadoraValidationService validation = new OperadoraValidationService();
            List<Message> messages = new List<Message>();

            try
            {
                contextoDB.IniciarTransacao();

                foreach (Operadora entity in entities)
                {
                    messages.AddRange(validation.ValidateEntityDeletion(entity, (IOperadoraRepository)repository));
                    repository.Excluir(entity);
                }

                if (messages.HasError())
                {
                    contextoDB.Rollback();
                    return messages;
                }

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
    }
}
