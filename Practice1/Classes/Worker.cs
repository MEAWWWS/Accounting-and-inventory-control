using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Classes
{
    public class Worker
    {
        [Key]
        public int id {  get; set; }
        public string fcs { get; set; }
        public string invNumber { get; set; }
        public string equip { get; set; }
        public float cost { get; set; }
        public string adress { get; set; }

        public Worker()
        {
            
        }
    }
}
