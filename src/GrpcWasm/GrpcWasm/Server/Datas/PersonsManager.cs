using GrpcWasm.Shared;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrpcWasm.Server.Datas
{
	public class PersonsManager
	{
		public List<Person> AllPeople { get; set; }

		public PersonsManager()
		{
			string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datas", "generated.json");
			if (File.Exists(pathFile))
			{
				string content = File.ReadAllText(pathFile);
				AllPeople = JsonSerializer.Deserialize<List<Person>>(content);
			}
		}
	}
}
