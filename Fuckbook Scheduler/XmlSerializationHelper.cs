using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Facebook_Scheduler
{
    public class XmlSerializationHelper
    {
        static public void Serialize(object obj, Type type, string path)
        {
            var serializer = new XmlSerializer(type);
            using (TextWriter writer = new StreamWriter(path, true, Encoding.UTF8))
            {
                serializer.Serialize(writer, obj);
            }
        }
    }
}
