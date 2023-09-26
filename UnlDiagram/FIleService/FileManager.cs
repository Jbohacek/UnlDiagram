using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnlDiagram.Essentials;

namespace UnlDiagram.FIleService
{
    public class FileManager
    {
        public static Result<bool> WriteToXmlFile<T>(T objectToWrite, string path = "") where T : new()
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                path = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
                path = Path.Combine(path, "TestFiles");
                path += $@"\Test_{new Random().Next(0, 10000)}_{DateTime.Now.ToShortDateString()}.xml";
            }
            TextWriter? writer = null;

            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(path, false);
                serializer.Serialize(writer, objectToWrite);
            }
            catch (Exception x)
            {
                return new Result<bool>(x.Message);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
            return new Result<bool>(true);
        }

        public static T ReadFromXmlFile<T>(string path) where T : new()
        {
            TextReader? reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(path);
                var ret = serializer.Deserialize(reader);
                if (ret != null)
                {
                    return (T)ret;
                }
                else
                {
                    return new T();
                }
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
