using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [BsonIgnoreExtraElements]
    //^ that tells the program to just ignore any properties that arent identified 
    public class Shipwreck
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("feature_type")]
        public string FeatureType { get; set; }

        [BsonElement("chart")]
        public string Chart { get; set; }

        [BsonElement("latdec")]
        public double Lat { get; set; }

        [BsonElement("londec")]
        public double Long { get; set; }

        //This acts as a container for data that we are not using but it will take up processing data
        //[BsonExtraElements]
        //public object[] Bucket { get; set; }

    }
}
