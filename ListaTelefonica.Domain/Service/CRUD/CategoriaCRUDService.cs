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
    public class CategoriaCRUDService : CRUDService<Categoria>
    {
        public override IList<Message> Inserir(Categoria entity, IRepository<Categoria> repository, IContextoDB contextoDB)
        {
            CategoriaValidationService validation = new CategoriaValidationService();
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

        public override IList<Message> Atualizar(Categoria entity, IRepository<Categoria> repository, IContextoDB contextoDB)
        {
            CategoriaValidationService validation = new CategoriaValidationService();
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

        public override IList<Message> Excluir(Categoria entity, IRepository<Categoria> repository, IContextoDB contextoDB)
        {
            CategoriaValidationService validation = new CategoriaValidationService();
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

        public IList<Message> Excluir(IList<Categoria> entities, IRepository<Categoria> repository, IContextoDB contextoDB)
        {
            CategoriaValidationService validation = new CategoriaValidationService();
            List<Message> messages = new List<Message>();

            try
            {
                contextoDB.IniciarTransacao();

                foreach (Categoria entity in entities)
                {
                    messages.AddRange(validation.ValidateEntityDeletion(entity, (ICategoriaRepository)repository));
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
