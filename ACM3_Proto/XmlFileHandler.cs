using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace FadingUtility.Helpers
{
    public class XmlFileHandler
    {
        /// <summary>
        /// Save any object that is serializable to a file.
        /// </summary>
        /// <param name="filename">File to save to</param>
        /// <param name="obj">object to save</param>
        /// <returns>true, if successfull</returns>
        public static bool SaveToFile(string filename, object obj)
        {
            bool saved_ok = true;
            XmlTextWriter xwr = null;
            try
            {
                xwr = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
                xwr.Formatting = Formatting.Indented;
                xwr.Indentation = 2;

                //Write the beginning of the document including the 
                //document declaration. Standalone is true. 
                xwr.WriteStartDocument(true);

                XmlSerializer serializer = new XmlSerializer(obj.GetType());

                serializer.Serialize(xwr, obj);
            }
            catch
            {
                saved_ok = false;
                throw;
            }
            finally
            {
                //End the document
                if (xwr != null)
                {
                    xwr.WriteEndDocument();
                    xwr.Close();	//flush and close file 
                }
            }
            return saved_ok;
        }

        /// <summary>
        /// Load object from xml file
        /// </summary>
        /// <param name="filename">XML file to load</param>
        /// <param name="objtype">Type of object stored in file</param>
        /// <returns>Object readed from file</returns>
        public static object ReadFromFile(string filename, Type objType)
        {
            StreamReader rdr = null;
            try
            {
                rdr = new StreamReader(filename);
                XmlTextReader xreader = new XmlTextReader(rdr);
                XmlSerializer serializer = new XmlSerializer(objType);
                return serializer.Deserialize(xreader);
            }
            catch
            {
                //Re-throw the event to the calling function
                throw;
            }
            finally
            {
                if (rdr != null)
                    rdr.Close();
            }
        }
    }
}
