using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace BAL
{
    public class FileOperation : IFileOperation
    {
        private string  folderName = "Output";
        public FileOperation()
        {
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
        }
        public bool WriteToSpecifiedFile(int[] intArray, string fileType)
        {
            try
            {
                if(fileType=="json")
                    if (WriteToJsonFile(intArray))
                        return true;
                if (fileType == "text")
                    if (WriteToTextFile(intArray))
                        return true;
                if (fileType == "xml")
                    if (WriteToXmlFile(intArray))
                        return true;
                else
                    return false;

                return false;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private bool WriteToJsonFile(int[] array)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize<int[]>(array);
                string fileName = folderName + "/jsonoutput"+ Guid.NewGuid().ToString()+".json";
                File.WriteAllText(fileName, jsonString);
                return true;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        private bool WriteToXmlFile(int[] array)
        {
            try
            {
                string fileName = folderName + "/xmlOutput" + Guid.NewGuid().ToString() + ".xml";
                using (XmlWriter writer = XmlWriter.Create(fileName))
                {
                    writer.WriteStartElement("Elements");
                    for (int i = 0; i < array.Length; i++)
                    {
                        writer.WriteElementString("Element", array[i].ToString());
                    }
                    writer.WriteEndElement();
                    writer.Flush();
                }
                return true;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }


        private bool WriteToTextFile(int[] array)
        {
            try
            {
                string fileName = folderName + "/textOutput" + Guid.NewGuid().ToString() + ".text";
                string [] strArray = new string[] { string.Join(',', array)};
                File.WriteAllLines(fileName, strArray);
                return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
