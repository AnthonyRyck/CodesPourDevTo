
using ExRam.Gremlinq.Core.GraphElements;

namespace EveCosmoGremlin.Models
{
	
	public class SolarSystemVertex : Vertex
	{
		//public SolarSystemVertex(int solar, string name, string security, string region)
		//{
		//	this.solar = solar;
		//	this.name = name;
		//	this.security = security;
		//	this.region = region;
		//}

		public VertexProperty<int> solar { get; set; }

		public VertexProperty<string> name { get; set; }

		public VertexProperty<string> security { get; set; }

		public VertexProperty<string> region { get; set; }
	}
}
