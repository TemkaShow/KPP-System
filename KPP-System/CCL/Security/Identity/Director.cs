using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Director 
        : User
    {
        public Director(int id, string name, string email, string phoneNumber, string address, string department, DateTime hireDate, int passId)
            : base(id, name, email, phoneNumber, address, department, hireDate, passId, nameof(Director))
        {
        }
    }

}
