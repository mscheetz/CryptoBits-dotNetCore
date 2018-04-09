using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Crypto
{
    [DataContract]
    [Serializable]
    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract class Entity : IEntity<string>
    {
        [DataMember]
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; set; }
    }
}
