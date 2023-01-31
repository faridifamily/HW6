using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public class UserRepository:IUserRepository
    {
        string path = @"D:\HW6\FileDataStorage.csv";
        public User Create(string name, long mobile, DateTime birthDate)
        {
            var users = List();
            User lastUser = new();
            if (users.Any())
            {
                lastUser = users[users.Count - 1];
            }
            User newUser = new();
            newUser.Id = lastUser.Id + 1;
            if (lastUser.Id == 0)
            {
                newUser.Id = 1;
            }
            newUser.Name = name;
            newUser.Mobile = mobile;
            newUser.BirthDate = birthDate;
            newUser.CreatedTime = DateTime.Now;
            File.AppendAllText(path, $"{newUser.Id},{name},{mobile},{birthDate},{newUser.CreatedTime}\n");
            return newUser;
        }
        public User Create(User user)
        {
            File.AppendAllText(path, $"{user.Id},{user.Name},{user.Mobile},{user.BirthDate},{user.CreatedTime}\n");
            return user;
        }
        //public void Read() { }
        public List<User> List() 
        {
            List<User> list = new();
            var users = File.ReadAllLines(path);
            foreach (var user in users)
            {
                var props = user.Split(",");
                User u = new();
                u.Id = int.Parse(props[0]);
                u.Name = props[1];
                u.Mobile= long.Parse(props[2]);
                u.BirthDate = DateTime.Parse(props[3]);
                u.CreatedTime = DateTime.Parse(props[4]);
                list.Add(u);
            }
            return list;
        }
        public User Detail(int id) 
        {
            var list = List();
            var user = list.Find(x => x.Id == id);
            if (user is not null)
            {
                return user;
            }
            return null;
        }

        public User Update(int id, User inputUser) 
        {
            var user = Detail(id);
            if (user is not null)
            {
                var users = List();
                File.WriteAllText(path, string.Empty);
                foreach (var item in users)
                {
                    if (user.Id == item.Id)
                    {
                        Create(inputUser);
                    }
                    else
                    {
                        Create(item);
                    }
                }
            }
            return user;
        }
        public void Delete(int id) 
        {
            var users = List();
            File.WriteAllText(path, string.Empty);
            foreach (var user in users)
            {
                if (user.Id != id)
                {
                    Create(user);
                }
            }
        }
    }
}
