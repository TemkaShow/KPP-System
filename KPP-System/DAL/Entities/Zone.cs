using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SecurityLvl { get; set; }
        public int Capacity { get; set; }
        public int Currentoccupancy { get; set; }
    }
}
