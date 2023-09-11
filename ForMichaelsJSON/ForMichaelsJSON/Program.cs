using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

class Program
{
    static void Main()
    {
        string jsonFilePath = "C:\\Users\\kfalcone\\source\\repos\\ForMichaelsJSON\\ForMichaelsJSON\\json1.json";
        if (File.Exists(jsonFilePath))
        {
            // Use File.ReadAll to Read from a file
            string jsonContent = File.ReadAllText(jsonFilePath);

            // We can Parse it into an Object JOject.Parse
            JToken jsonObject = JToken.Parse(jsonContent);
            DisplayJson(jsonObject);

        }
        else
        {
            Console.WriteLine($"{jsonFilePath}");
        }

        // We assign the indent param to keep a good json structure
        static void DisplayJson(JToken token, string indent = "")
        {
            if(token is JObject jsonObject)
            {
                foreach (var property in jsonObject.Properties())
                {
                    Console.WriteLine($"{indent}{property.Name}:");
                    DisplayJson(property.Value, indent + "  ");
                }
            }
            // loop through each of its properties and print in the json structure
            
           else if (token is JArray jsonArray)
            {
                int index = 1;
                foreach (var items in jsonArray)
                {
                    Console.WriteLine($"{indent}[{index}]:");
                    DisplayJson(items, indent + "  ");
                    index++;
                }
            }
            else
            {
                Console.WriteLine($"{indent}{token}");
            }
        }
    }
}