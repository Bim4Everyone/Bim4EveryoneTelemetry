using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Bim4EveryoneTelemetry.JsonConverters;

public class DynamicDataBsonSerializer : SerializerBase<string?> {
    public override string Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) {
        return BsonDocumentSerializer.Instance.Deserialize(context).ToString();
    }

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string? value) {
        if(value == null) {
            return;
        }

        var bsonDocument = BsonDocument.Parse(value?.ToString());
        BsonDocumentSerializer.Instance.Serialize(context, bsonDocument);
    }
}