using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMongo.Models
{
	public class Commande : MongoId
	{
		[BsonElement("ClientId")]
		public string ClientId { get; set; }


	}
}
