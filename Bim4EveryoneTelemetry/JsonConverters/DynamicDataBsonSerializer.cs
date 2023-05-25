using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Bim4EveryoneTelemetry.JsonConverters;

public class DynamicDataBsonSerializer : SerializerBase<string?> {
    public override string? Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) {
        if(context.Reader.CurrentBsonType == BsonType.Null) {
            return null;
        }

        return BsonDocumentSerializer.Instance.Deserialize(context).ToString();
    }

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string? value) {
        if(string.IsNullOrEmpty(value)) {
            return;
        }

        var bsonDocument = BsonDocument.Parse(value);
        BsonDocumentSerializer.Instance.Serialize(context, bsonDocument);
    }
}