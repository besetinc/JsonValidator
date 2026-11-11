using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;

namespace JsonValidator
{
    public static class JsonHandler
    {
        public static JToken Validate(string json)
        {
            return JToken.Parse(json);
        }
        public static bool ValidateSchema(JToken jsonToken, JSchema schema, out IList<string> validationErrors)
        {
            return jsonToken.IsValid(schema, out validationErrors);
        }
        public static JSchema ParseSchema(string schemaJson)
        {
            return JSchema.Parse(schemaJson);
        }
        public static string Format(string json)
        {
            return JToken.Parse(json).ToString(Formatting.Indented);
        }
        public static string Minify(string json)
        {
            return JToken.Parse(json).ToString(Formatting.None);
        }
    }
}