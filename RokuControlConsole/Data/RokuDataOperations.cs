using RokuControlConsole.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RokuControlConsole.Data
{
    public class RokuDataOperations
    {
        private static RokuDataOperations rokuDataOperations;
        private static Dictionary<string, RokuDevice> rokuDevices;
        private const string FILENAME = "saved_devices.json";

        private RokuDataOperations()
        {
            rokuDevices = new Dictionary<string,RokuDevice>();
        }

        public static RokuDataOperations Instance()
        {
            if(rokuDataOperations == null)
            {
                rokuDataOperations = new RokuDataOperations();
            }

            return rokuDataOperations;
        }

        public void AddRokuDevice(string deviceId, RokuDevice rokuDevice)
        {
            if (rokuDevices.ContainsKey(deviceId))
            {
                Console.WriteLine("Device already saved");
            }
            else
            {
                rokuDevices.Add(deviceId, rokuDevice);
            }
        }

        public void RemoveDevice(string deviceId)
        {
            if (!rokuDevices.ContainsKey(deviceId))
            {
                Console.WriteLine("Device has not been added to the device list");
            }
            else
            {
                if (rokuDevices.Remove(deviceId))
                {
                    Console.WriteLine("Device removed");
                }
                else
                {
                    Console.WriteLine("Unable to remove device");
                }
            }
        }

        public async Task SaveDevices()
        {
            try
            {
                using FileStream createStream = File.Create(FILENAME);
                await JsonSerializer.SerializeAsync(createStream, rokuDevices);
                await createStream.DisposeAsync();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Can't write data to file");
                Console.ResetColor();
                throw;
            }
        }

        public async Task LoadDevices()
        {
            if (File.Exists(FILENAME))
            {
                try
                {
                    using FileStream openStream = File.OpenRead(FILENAME);
                    rokuDevices = await JsonSerializer.DeserializeAsync<Dictionary<string, RokuDevice>>(openStream);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Can't read data from file");
                    Console.ResetColor();
                    throw;
                }
            }
        }

        public void PrintSavedDevices()
        {
            if(rokuDevices.Count > 0)
            {
                Console.WriteLine($"Found {rokuDevices.Count} saved device(s)");
                foreach(RokuDevice device in rokuDevices.Values)
                {
                    Console.WriteLine($"{device.IPAddress}: {device.FriendlyDeviceName} ({device.ModelName})");
                }
            }
            else
            {
                Console.WriteLine("No devices saved");
            }
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
