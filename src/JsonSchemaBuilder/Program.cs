using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;


namespace JsonSchemaBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //  https://www.newtonsoft.com/jsonschema/help/html/GeneratingSchemas.htm

            JSchemaGenerator generator = new JSchemaGenerator();

            JSchema schema = generator.Generate(typeof(TargetClassToCreateSchema));

            File.WriteAllText("./output.schema.json", schema.ToString());

            //StringBuilder sb = new StringBuilder();
            //StringWriter sw = new StringWriter(sb);

            //using (JsonWriter writer = new JsonTextWriter(sw))
            //{
            //    writer.Formatting = Formatting.Indented;

            //    schema.WriteTo(writer);

            //}

            //JSchemaWriterSettings settings

        }
    }
}
