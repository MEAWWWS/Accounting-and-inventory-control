using System.ComponentModel.DataAnnotations;
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
