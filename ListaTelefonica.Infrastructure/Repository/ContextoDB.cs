using System;
using System.Data.Entity;
using System.Linq;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;

namespace ListaTelefonica.Infrastructure.Repository
{
    public class ContextoDB : DbContext, IContextoDB
    {
        public ContextoDB() : base("ListaTelefonica_DB") { }

        private DbContextTransaction Transacao { get; set; }

        public IQueryable<T> Query<T>() where T : class
        {
            var retorno = this.Set<T>();
            return this.Set<T>();
        }

        public void IniciarTransacao()
        {
            Transacao = this.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (Transacao == null)
            {
                throw new NullReferenceException("Transacao não foi aberta.");
            }
            else
            {
                Transacao.Commit();
                Transacao.Dispose();
            }
        }        

        public void Rollback()
        {
            if (Transacao == null)
            {
                throw new NullReferenceException("Transacao não foi aberta.");
            }
            else
            {
                Transacao.Rollback();
                Transacao.Dispose();
            }
        }

        public void Inserir<T>(T entity) where T : class
        {
            this.Set<T>().Add(entity);
            this.SaveChanges();
        }

        public void Atualizar<T>(T entity) where T : class
        {
            this.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        public void Excluir<T>(T entity) where T : class
        {
            this.Set<T>().Remove(entity);
            this.SaveChanges();
        }

        public DbSet<Contato> Contato { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Operadora> Operadora { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        
    }
}
