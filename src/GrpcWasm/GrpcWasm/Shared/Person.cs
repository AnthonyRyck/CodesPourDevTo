using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWasm.Shared
{
	public class Person
    {
		public string id { get; set; }
		public int index { get; set; }
		public string guid { get; set; }
		public bool isActive { get; set; }
		public string balance { get; set; }
		public int age { get; set; }
		public string eyeColor { get; set; }
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
	}
}
