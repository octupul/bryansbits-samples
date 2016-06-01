using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;

namespace Hub_Feeder.Access
{
    public class IOTHubAccess
    {
        private List<Device> devices = new List<Device>();
        private DeviceClient _deviceClient;
        static RegistryManager _registryManager;
        private DeviceClient _DeviceClient;
        private string _iotHubURL;
        private string _connStr;
        private string _iotkey;

        public IOTHubAccess(string connString)
        {
            _connStr = connString;

            _registryManager = RegistryManager.CreateFromConnectionString(_connStr);
        }

        public async Task<List<Device>> RegisterDevices(int numberOfDevices)
        {
            devices.Clear();

            for (int i = 0; i < numberOfDevices; i++)
            {
                var device = new Device(Guid.NewGuid().ToString());

                await _registryManager.AddDeviceAsync(device);

                device.Status = DeviceStatus.Enabled;

                await _registryManager.UpdateDeviceAsync(device);

            }

            return devices;
        }

        public async Task AddToHub(Device device, object message)
        {
               _DeviceClient = DeviceClient.Create(_iotHubURL, new DeviceAuthenticationWithRegistrySymmetricKey(device.Id, _iotkey));
               await _DeviceClient.SendEventAsync( new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(message))));
        }
    }
}
