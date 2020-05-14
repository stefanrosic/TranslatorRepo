using System;
using System.Linq;
using System.Xml;
using TranslatorToolApp.Models;

namespace TranslatorToolApp.Data.XML
{
    public class TranslationXML
    {

        public static String STORAGE_DIRECTORY = AppDomain.CurrentDomain.BaseDirectory + "/Data/Storage/out.xml";

        public static void ProcessStoring(Translation translationObj)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(STORAGE_DIRECTORY);
            }
            catch(Exception ex)
            {
                generateXML();
            }
            finally
            {
                StoreTranslation(translationObj);
            }
        }

        private static void generateXML()
        {
            XmlDocument doc = new XmlDocument();

            XmlNode XMLdeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(XMLdeclaration);

            doc.AppendChild(doc.CreateElement("translations"));
            doc.Save(STORAGE_DIRECTORY);
        }

        private static void StoreTranslation(Translation translationObj)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(STORAGE_DIRECTORY);

            XmlNode translations = doc.SelectSingleNode("translations");
            XmlElement translation = (XmlElement) translations.AppendChild(doc.CreateElement("translation"));

            DateTime now = DateTime.Now;

            translation.SetAttribute("timestamp", now.ToString());
            translation.SetAttribute("id", 1 + "");

            XmlElement from = (XmlElement)translation.AppendChild(doc.CreateElement("from"));
            XmlElement to = (XmlElement)translation.AppendChild(doc.CreateElement("to"));

            from.InnerText = translationObj.TranslateFrom;
            to.InnerText = translationObj.TranslateTo;

            doc.Save(STORAGE_DIRECTORY);
        }
    }
}