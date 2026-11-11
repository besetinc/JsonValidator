
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using JsonValidator;
using System.Collections.Generic;

namespace JsonValidator.Tests
{
    [TestClass]
    public class JsonHandlerTests
    {
        [TestMethod]
        public void ValidateEmptyJsonTest()
        {
            string json = "";

            Assert.ThrowsExactly<JsonReaderException>(() =>
                JsonHandler.Validate(json));
        }
        [TestMethod]
        public void ValidateValidJsonTest()
        {
            string json = "{\"machineName\":\"agent01\",\"isOnline\":true}";

            JToken result = JsonHandler.Validate(json);

            Assert.IsNotNull(result);
            Assert.AreEqual("agent01", result["machineName"]?.ToString());
        }

        [TestMethod]
        public void ValidateInvalidJsonTest()
        {
            string json = "{\"machineName\":\"agent01\",\"isOnline\":true";

            Assert.ThrowsExactly<JsonReaderException>(() =>
                JsonHandler.Validate(json));
        }

        [TestMethod]
        public void FormatValidJsonTest()
        {
            string json = "{\"machineName\":\"agent01\",\"isOnline\":true}";

            string expected = """
            {
              "machineName": "agent01",
              "isOnline": true
            }
            """;

            string result = JsonHandler.Format(json);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FormatInvalidJsonTest()
        {
            string json = "{\"machineName\":\"agent01\",\"isOnline\":true";

            Assert.ThrowsExactly<JsonReaderException>(() =>
                JsonHandler.Format(json));
        }

        [TestMethod]
        public void MinifyValidJsonTest()
        {
            string json = "{ \"machineName\": \"agent01\", \"isOnline\": true }";

            string result = JsonHandler.Minify(json);

            Assert.AreEqual(
                "{\"machineName\":\"agent01\",\"isOnline\":true}",
                result);
        }

        [TestMethod]
        public void MinifyInvalidJsonTest()
        {
            string json = "{\"machineName\":\"agent01\",\"isOnline\":true";

            Assert.ThrowsExactly<JsonReaderException>(() =>
                JsonHandler.Minify(json));
        }

        [TestMethod]
        public void ValidateSchemaValidJsonTest()
        {
            string schemaJson = """
                {
                    "type": "object",
                    "properties": {
                        "machineName": { "type": "string" },
                        "isOnline": { "type": "boolean" }
                    },
                    "required": ["machineName", "isOnline"]
                }
                """;

            JSchema schema = JsonHandler.ParseSchema(schemaJson);
            JToken json = JsonHandler.Validate(
                "{\"machineName\":\"agent01\",\"isOnline\":true}");

            bool result = JsonHandler.ValidateSchema(
                json, schema, out IList<string> errors);

            Assert.IsTrue(result);
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void ValidateSchemaInvalidJsonTest()
        {
            string schemaJson = """
                {
                    "type": "object",
                    "properties": {
                        "machineName": { "type": "string" },
                        "isOnline": { "type": "boolean" }
                    },
                    "required": ["machineName", "isOnline"]
                }
                """;

            JSchema schema = JsonHandler.ParseSchema(schemaJson);
            JToken json = JsonHandler.Validate(
                "{\"machineName\":\"agent01\",\"isOnline\":\"yes\"}");

            bool result = JsonHandler.ValidateSchema(
                json, schema, out IList<string> errors);

            Assert.IsFalse(result);
            Assert.IsTrue(errors.Count > 0);
        }

        [TestMethod]
        public void ParseSchemaValidSchemaTest()
        {
            string schemaJson = """
                {
                    "type": "object",
                    "properties": {
                        "machineName": { "type": "string" },
                        "isOnline": { "type": "boolean" }
                    }
                }
                """;

            JSchema schema = JsonHandler.ParseSchema(schemaJson);

            Assert.IsNotNull(schema);
            Assert.AreEqual(JSchemaType.Object, schema.Type);
        }

        [TestMethod]
        public void ParseSchemaInvalidSchemaTest()
        {
            string schemaJson = "{\"type\":\"unknown\"}";

            Assert.ThrowsExactly<JSchemaReaderException>(() =>
                JsonHandler.ParseSchema(schemaJson));
        }
    }
}
