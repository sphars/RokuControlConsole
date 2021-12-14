using RokuControlConsole.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RokuControlConsole.Data
{
    public class RokuDataOperations
    {
        public static void SendRokuCommand(RokuCommand command)
        {

            Uri url = new(RokuConfig.BaseUrl + command.Path);

            var t = Task.Run(() => RokuClient.PostCommand(url, ""));
            t.Wait();

            Console.WriteLine(t.Result);
        }

        public static RokuDevice DeserializeXMLToRokuDevice(string xmlContent)
        {
            RokuDevice rokuDevice = new RokuDevice();
            XmlSerializer serializer = new XmlSerializer(typeof(RokuDevice));

            TextReader reader = new StringReader(xmlContent);

            rokuDevice = (RokuDevice)serializer.Deserialize(reader);

            return rokuDevice;

        }

    }
}
