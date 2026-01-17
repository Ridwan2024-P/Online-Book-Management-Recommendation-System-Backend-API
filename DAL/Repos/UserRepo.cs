using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserRepo
    {
        PMSContext db;
        public UserRepo(PMSContext db)
        {
            this.db = db;
        }

        public bool Create(User user)
        {
            db.Users.Add(user);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }
        public bool update(User user)
        {
            var ex = Get(user.Id);
            db.Entry(ex).CurrentValues.SetValues(user);
            return db.SaveChanges() > 0;

        }
        public bool delete(int id)
        {
            var ex = Get(id);
            db.Users.Remove(ex);
            return db.SaveChanges() > 0;
        }
    }
}
