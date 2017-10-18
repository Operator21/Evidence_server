using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidence_server
{
    public class User
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string birth_num { get; set; }
        public DateTime birth { get; set; }
        public string gender { get; set; }
    }
}
