using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSC2033_TeamProject.Content.Classes
{

    //generic serialiser for saving & loadingcontent to and from disk
    public static class Serialisation
    {
        /*
         
        public static T? DeserialiseXMLFile<T>(string filePath)
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(T));
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                    return (T)serialiser.Deserialize(fileStream);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in file deserialisation");
            }
            return default(T);
        }

        public static void SerialiseXMLFile<T>(object obj, string fileName)
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(T));
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                    serialiser.Serialize(writer, obj);

            }
            catch (Exception e)
            {
                MessageBox.Show("Error in file serialisation: " + e.Message + " " + e.InnerException);
            }
            
        }
        */


    }
}
