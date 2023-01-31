using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long? Mobile { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
