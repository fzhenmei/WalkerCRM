using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WalkerCRM.Domain;

namespace WalkerCRM.Web.Mvc.Models
{ 
    public class UserRepository : IUserRepository
    {
        WalkerCRMWebMvcContext context = new WalkerCRMWebMvcContext();

        public IQueryable<User> All
        {
            get { return context.Users; }
        }

        public IQueryable<User> AllIncluding(params Expression<Func<User, object>>[] includeProperties)
        {
            IQueryable<User> query = context.Users;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public User Find(int id)
        {
            return context.Users.Find(id);
        }

        public void InsertOrUpdate(User user)
        {
            if (user.Id == default(int)) {
                // New entity
                context.Users.Add(user);
            } else {
                // Existing entity
                context.Entry(user).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var user = context.Users.Find(id);
            context.Users.Remove(user);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IUserRepository
    {
        IQueryable<User> All { get; }
        IQueryable<User> AllIncluding(params Expression<Func<User, object>>[] includeProperties);
        User Find(int id);
        void InsertOrUpdate(User user);
        void Delete(int id);
        void Save();
    }
}