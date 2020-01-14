using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace SetupWizard
{
    class Helper
    {
        public static void Serialize(string filePath, object o)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            XmlSerializer formatter = new XmlSerializer(o.GetType());
            try
            {
                formatter.Serialize(fs, o);
            }
            catch (SerializationException e)
            {
                throw e;
            }
            finally
            {
                fs.Close();
            }
        }


        public static T Deserialize<T>(string filePath) where T : new()
        {
            T serializeObject = default(T);

            FileStream fs = new FileStream(filePath, FileMode.Open);
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                serializeObject = (T)formatter.Deserialize(fs);
                return serializeObject;
            }
            catch (SerializationException e)
            { 
                throw e;
            }
            finally
            {
                fs.Close();
            }

        }
    }
}
