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
        public static Result<bool> WriteToXmlFile<T>(T objectToWrite) where T : new()
        {
            string savePath = AppDomain.CurrentDomain.BaseDirectory;
            savePath = Path.GetFullPath(Path.Combine(savePath, @"..\..\..\"));
            savePath = Path.Combine(savePath, "TestFiles");
            savePath += $@"\Test_{DateTime.Now.ToShortDateString()}_{new Random().Next(0,10000)}.xml";

            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(savePath, false);
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
    }
}
