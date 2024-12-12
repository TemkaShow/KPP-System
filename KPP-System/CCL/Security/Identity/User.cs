using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public abstract class User
    {
        public User(int id, string name, string email, string phoneNumber, string address, string department, DateTime hireDate, int passId, string userType)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Department = department;
            HireDate = hireDate;
            PassId = passId;
        }
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public string Address { get; }
        public string Department { get; }
        public DateTime HireDate { get; }
        public int PassId { get; }
        public string UserType { get; }
    }
}
