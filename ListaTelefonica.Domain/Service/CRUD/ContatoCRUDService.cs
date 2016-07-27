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
    public class ContatoCRUDService : CRUDService<Contato>
    {
        public override IList<Message> Inserir(Contato entity, IRepository<Contato> repository, IContextoDB contextoDB)
        {
            ContatoValidationService validation = new ContatoValidationService();
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

        public override IList<Message> Atualizar(Contato entity, IRepository<Contato> repository, IContextoDB contextoDB)
        {
            ContatoValidationService validation = new ContatoValidationService();
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

        public override IList<Message> Excluir(Contato entity, IRepository<Contato> repository, IContextoDB contextoDB)
        {
            ContatoValidationService validation = new ContatoValidationService();
            IList<Message> messages = validation.ValidateEntityDeletion(entity, (IContatoRepository)repository);

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

        public IList<Message> Excluir(IList<Contato> entities, IRepository<Contato> repository, IContextoDB contextoDB)
        {
            ContatoValidationService validation = new ContatoValidationService();
            List<Message> messages = new List<Message>();
            IContatoRepository castedRepository = (IContatoRepository)repository;

            try
            {
                contextoDB.IniciarTransacao();

                foreach (Contato entity in entities)
                {
                    messages.AddRange(validation.ValidateEntityDeletion(entity, castedRepository));
                    castedRepository.ExcluirComTelefoneDependente(entity);                    
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
