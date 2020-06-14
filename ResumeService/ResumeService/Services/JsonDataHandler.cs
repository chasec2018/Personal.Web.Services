using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;


namespace ResumeService.Services
{
    public enum JsonAppDataObjectType
    {
        ArrayType,
        DictionaryProperty
    }

    public class JsonDataHandler
    {
        public T ReturnGenericJsonObject<T>(string DataFile)
        {
            // Validate DataFile Exits
            if (!File.Exists(DataFile))
                throw new FileNotFoundException();
            try
            {
                using (FileStream Stream = new FileStream(DataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader Reader = new StreamReader(Stream))
                    {
                        return JsonSerializer.Deserialize<T>(Reader.ReadToEnd());
                    }
                }
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public void AppendNewArrayJsonObject<T>(string DataFile, T DataObject)
        {
            // Validate DataFile Exits
            if (!File.Exists(DataFile))
                throw new FileNotFoundException();

            // Store Data from Json File into variable for validation
            string data = File.ReadAllText(DataFile);

            try
            {
                // Validate string length
                if (data.Length.Equals(0))
                {
                    List<T> JsonObject = new List<T>();
                    JsonObject.Add(DataObject);
                    File.WriteAllText(DataFile, JsonSerializer.Serialize<List<T>>(JsonObject));
                }
                else
                {
                    List<T> JsonObject = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(DataFile));
                    JsonObject.Add(DataObject);
                    File.WriteAllText(DataFile, JsonSerializer.Serialize<List<T>>(JsonObject));
                }
            }
            catch(Exception exception)
            {
                if (data.Length > 0)
                    File.WriteAllText(DataFile, data);

                throw exception;
            }
        }

        public void EditArrayJsonObject<T>(string DataFile, T OldDataObject, T NewDataObject)
        {
            using (FileStream Stream = new FileStream(DataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader Reader = new StreamReader(Stream))
                {
                    List<T> JsonObject = JsonSerializer.Deserialize<List<T>>(Reader.ReadToEnd());

                    T item;

                    try
                    {
                        for (int i = 0; i < JsonObject.Count; i++)
                        {
                            if (JsonObject[i].Equals(OldDataObject))
                            {
                                item = JsonObject[i];
                                JsonObject.Remove(item);
                                break;
                            }
                        }

                        JsonObject.Add(NewDataObject);
                        File.WriteAllText(DataFile, JsonSerializer.Serialize<List<T>>(JsonObject));

                    }
                    catch (Exception exception)
                    {
                        throw exception;

                    }
                }
            }
        }
    }
}
