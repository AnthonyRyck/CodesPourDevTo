﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConsoleMongo.Models
{
	public class MongoId
	{
		[BsonId]
		public ObjectId Id { get; set; }

	}
}
