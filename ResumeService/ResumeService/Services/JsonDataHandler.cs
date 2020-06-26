using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace ResumeService.Services
{
    public class JsonDataHandler
    {
        public bool ExceptionOccurred { get; set; } = false;
        public Exception JsonHandlerException { get; set; }

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

        public async Task<T> ReturnGenericJsonObjectAsync<T>(string DataFile) where T : class, new()
        {
            try
            {
                if (!File.Exists(DataFile))
                    throw new FileNotFoundException();

                using (FileStream Stream = new FileStream(DataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader Reader = new StreamReader(Stream))
                    {
                        return JsonSerializer.Deserialize<T>(await Reader.ReadToEndAsync());
                    }
                }
            }
            catch (Exception exception)
            {
                JsonHandlerException = exception;
                return null;
            }
        }

        /*
        public void AppendNewArrayJsonObject<T>(string DataFile, T DataObject)
        {
            // Validate DataFile Exits
            if (!File.Exists(DataFile))
                throw new FileNotFoundException();

            // Store Data from Json File into variable for validation
            string data = File.ReadAllText(DataFile);

            try
            {

                JsonSerializerOptions Options = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    IgnoreNullValues = true
                };

                // Validate string length
                if (data.Length.Equals(0))
                {
                    List<T> JsonObject = new List<T>();
                    JsonObject.Add(DataObject);
                    File.WriteAllText(DataFile, JsonSerializer.Serialize<List<T>>(JsonObject, Options));
                }
                else
                {
                    List<T> JsonObject = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(DataFile));
                    JsonObject.Add(DataObject);
                    File.WriteAllText(DataFile, JsonSerializer.Serialize<List<T>>(JsonObject, Options));
                }
            }
            catch(Exception exception)
            {
                if (data.Length > 0)
                    File.WriteAllText(DataFile, data);

                throw exception;
            }
        }
        */

        public void AppendGenericJsonObject<T>(string DataFile, T NewData, out bool IsSaved)
        {
            IsSaved = false;

            using (FileStream Stream = new FileStream(DataFile, FileMode.Truncate, FileAccess.Write, FileShare.Read))
            {
                try
                {

                    JsonSerializerOptions Options = new JsonSerializerOptions()
                    {
                        WriteIndented = true,
                        IgnoreNullValues = true
                    };

                    string NewJsonObject = JsonSerializer.Serialize<T>(NewData, Options);

                    using (StreamWriter Writer = new StreamWriter(Stream))
                    {
                        Writer.Write(NewJsonObject);
                        Writer.Flush();
                    }

                    IsSaved = true;

                }
                catch(Exception exception)
                {
                    JsonHandlerException = exception;
                }
            }
        }

        public async Task AppendGenericJsonObjectAsync<T>(string DataFile, T NewData) where T : class, new()
        {
            using (FileStream Stream = new FileStream(DataFile, FileMode.Truncate, FileAccess.Write, FileShare.Read))
            {
                try
                {
                    JsonSerializerOptions Options = new JsonSerializerOptions()
                    {
                        WriteIndented = true,
                        IgnoreNullValues = true
                    };

                    string NewJsonObject = JsonSerializer.Serialize<T>(NewData, Options);

                    using (StreamWriter Writer = new StreamWriter(Stream))
                    {
                        await Writer.WriteAsync(NewJsonObject);
                        await Writer.FlushAsync();
                    }

                }
                catch (Exception exception)
                {
                    JsonHandlerException = exception;
                }
            }
        }
    }
}
