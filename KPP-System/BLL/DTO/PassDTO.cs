using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PassDTO
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiretionDate { get; set; }
        public PassStatus Status { get; set; }
        public int UserId { get; set; }
    }
}
