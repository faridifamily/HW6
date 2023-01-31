using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public interface IUserRepository
    {
        public void Create(string name, int mobile, DateTime birthDate) { }
        //public void Read() { }
        public void List() { }
        public void Detail(int id) { }
        public void Update(int id) { }
        public void Delete(int id) { }
    }
}
