using System.Text.Json;
using System.Text.Json.Serialization;

namespace web_api_health_clinic.Utils
{
    public class TimeSpanConverter : JsonConverter<TimeSpan>
    {
       
            public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                string? value = reader.GetString();
                return TimeSpan.Parse(value!);
            }

            public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString(@"hh\:mm"));
            }
        
    }
}
