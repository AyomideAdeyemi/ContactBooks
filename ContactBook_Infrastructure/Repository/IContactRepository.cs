using ContactBook_Domain.Entities;
using ContactBook_Infrastructure.Persistence;
using ContactBooks_Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactBooks_Infrastructure.Repository
{
    public interface IContactRepository
    {
        Task Create(Contact entity);
        void Update(Contact entity);
        void Delete(Contact entity);
        Task SaveChangesAsync();
        Task<Contact> GetContactById(string id);
        IQueryable<Contact> FindByCondition(Expression<Func<Contact, bool>> expression, bool trackChanges);
        Task<Contact> GetContactBySearchTerms(string name, bool trackChanges);




    }
}
