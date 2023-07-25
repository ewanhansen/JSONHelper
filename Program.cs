using System.Text.Json;

namespace SerializeBasic
{
    public class PlayerData
    {
        //can use [JSONIgnore] to add fields that need not be serialized
        //these will likey be changed to suit the needs of the current project but should continue
        //to work without any issues
        public long SteamID {get; set;}
        public int Money { get; set; }
        public int Health { get; set; }
        public int[]? InventoryItems { get; set; }
    }

    public class Program
    {    
        public static void Main()
        {
            List<PlayerData> dataList = new();

            for (int i = 0; i < 100; i++)
            {
                var PlayerData = new PlayerData
                {
                    SteamID = 76561198146705130,
                    Money =  98 * i,
                    Health = 76
                };

                dataList.Add(PlayerData);
            }  

            SerializeObjectToJSON(dataList, "PlayerData.json", true);
            //DeserializeJSONToObject(dataList, "PlayerData.json");
        }

        public static void SerializeObjectToJSON(object objectToSerialize, string fileName, bool writeIdented)
        {         
            //write indented for easier reading by humans
            var _options = new JsonSerializerOptions { WriteIndented = writeIdented };
            //serialize object and write to file
            string _jsonString = JsonSerializer.Serialize(objectToSerialize, _options);
            File.WriteAllText(fileName, _jsonString);

            //Read out file to console
            Console.WriteLine(File.ReadAllText(fileName));
        }

        public static object? DeserializeJSONToObject(string fileName)
        {
            try
            {
                string jsonString = File.ReadAllText(fileName);
                var deserializedObject = JsonSerializer.Deserialize<object>(jsonString)!;

                //Read out file to console
                Console.WriteLine(deserializedObject + "TargetObject");
                return deserializedObject;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid JSON file, formatting may be incorrect." + e.ToString());
                return null;
            }   
        }       
    }   
}