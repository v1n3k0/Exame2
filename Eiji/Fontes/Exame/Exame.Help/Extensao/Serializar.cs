using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

namespace Exame.Help.Extensao
{
    public static class Serializar
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        //Qual diferença XmlWriter e MemoryStream?

        /// <summary>
        /// Serializar para XML
        /// </summary>
        /// <typeparam name="T">Tipo da classe</typeparam>
        /// <param name="objeto">objeto a ser serializado</param>
        /// <returns>String em XML</returns>
        public static string SerializarXML<T>(this T objeto)
        {
            var serializer = new DataContractSerializer(typeof(T));
            var stringBuilder = new StringBuilder();
            XmlWriter xmlWriter = null;

            try
            {
                xmlWriter = XmlWriter.Create(stringBuilder);
                serializer.WriteObject(xmlWriter, objeto);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "SerializarXML: ");
            }
            finally
            {
                if (xmlWriter != null)
                    xmlWriter.Close();
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Serializar para Json
        /// </summary>
        /// <typeparam name="T">Tipo da classe</typeparam>
        /// <param name="objeto">objeto a ser serializado</param>
        /// <returns>String em XML</returns>
        public static string SerializarJson<T>(this T objeto)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var memoryStream = new MemoryStream();
            string json = string.Empty;

            try
            {
                serializer.WriteObject(memoryStream, objeto);
                json = Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "SerializarJson: ");
            }
            finally
            {
                memoryStream.Close();
            }

            return json;
        }
    }
}
