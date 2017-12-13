using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository
    {
        private DBNews dbN;

        public Repository()
        {
            dbN = new DBNews();
        }

        public void Add(User user)
        {
            dbN.Entry(user).State = EntityState.Added;
        }

        public void Remove(User user)
        {
            dbN.Entry(user).State = EntityState.Deleted;
        }

        public User Update(User user)
        {
            dbN.Entry(user).State = EntityState.Modified;

            return user;
        }

        public IEnumerable<string> Read()
        {
            return dbN.Set<User>().Select(x=> x.UserName).ToList();
        }

        public User ChekByName(string name)
        {
            return dbN.Set<User>().Find(name);
        }

        public void SaveChanges()
        {
            dbN.SaveChanges();

        }
    }
}
