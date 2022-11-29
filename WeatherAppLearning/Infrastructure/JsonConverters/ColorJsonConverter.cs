using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherAppLearning.Infrastructure.JsonConverters;

internal class ColorJsonConverter : JsonConverter<Color>
{
    public override Color? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return Color.FromRgba(value);
    }

    public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToRgbaHex());
    }
}