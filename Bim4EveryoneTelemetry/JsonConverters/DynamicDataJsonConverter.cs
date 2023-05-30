using System.Collections;
using System.Dynamic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bim4EveryoneTelemetry.JsonConverters;

internal class DynamicDataJsonConverter : JsonConverter<string?> {
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        if(reader.TokenType == JsonTokenType.Null) {
            return null;
        }
        
        return JsonDocument.ParseValue(ref reader).RootElement.GetRawText();
    }

    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options) {
        writer.WriteStringValue(value);
    }
}