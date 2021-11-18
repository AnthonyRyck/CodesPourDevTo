using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoJson.Models
{
    public class Personne
    {
        public Guid id { get; set; }
        public int index { get; set; }
        public bool isActive { get; set; }
        public int age { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string about { get; set; }
        public string registered { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public Friend[] friends { get; set; }
        public string greeting { get; set; }
        public string favoriteFruit { get; set; }
    }

    public class Friend
    {
        public int id { get; set; }
        public string name { get; set; }
    }

}
