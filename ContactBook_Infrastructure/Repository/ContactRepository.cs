using ContactBook_Domain.Entities;
using ContactBook_Infrastructure.Persistence;
using ContactBooks_Domain.Dtos;
using ContactBooks_Infrastructure.Repository;
using ContactBooks_Shared.RequestParameter.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Infrastructure.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _appDbContext;

        public ContactRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IQueryable<Contact> FindByCondition(Expression<Func<Contact, bool>> expression, bool trackChanges)
        {
            return !trackChanges ?
                _appDbContext.Set<Contact>()
                .Where(expression)
                .AsNoTracking() :
                _appDbContext.Set<Contact>()
                .Where(expression);

        }
        public async Task<Contact> GetContactBySearchTerms(string name, bool trackChanges) =>
     await FindByCondition(x => x.Name == name, trackChanges).FirstOrDefaultAsync();

        public async Task<Contact> GetContactById(string id)
        {
            return await _appDbContext.Set<Contact>().FindAsync(id);
        }
        public async Task Create(Contact entity) => _appDbContext.Set<Contact>().Add(entity);
        public void Update(Contact entity) => _appDbContext.Set<Contact>().Update(entity);
        public void Delete(Contact entity) => _appDbContext.Set<Contact>().Remove(entity);
        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
