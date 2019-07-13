using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramGenerator
{
    public class Telegram
    {
        #region properties and empty ctor

        public readonly string cmd = "rx";
        public string eui { get; set; } //16 hex digits
        public double ts { get; set; } //server timestamp as number (milliseconds from Linux epoch)
        public bool ack { get; set; }
        public int fnct { get; set; } // frame counter, a 32-bit number
        public int port { get; set; }
        public string data { get; set; } // hex string 
        public long freq { get; set; }
        public int rssi { get; set; } // frame rssi, in dBm, as int
        public double snr { get; set; } // fram snr, in dBm, one decimal place

        public Telegram() { }

        public static Telegram RandomTelegram()
        {
            return new Telegram()
            {
                eui = Utils.GenerateHexString(16),
                ts = Convert.ToUInt64(Utils.GenerateRandomNumbers(13)),
                ack = Convert.ToInt16(Utils.GenerateRandomNumbers(3)) % 2 != 0,
                fnct = Convert.ToInt16(Utils.GenerateRandomNumbers(3)) % 10,
                port = Convert.ToInt16(Utils.GenerateRandomNumbers(3)) % 3,
                data = Utils.GenerateHexString(22),
                freq = Convert.ToInt64(Utils.GenerateRandomNumbers(8)),
                rssi = Convert.ToInt32(Utils.GenerateRandomNumbers(3)),
                snr = Convert.ToDouble(Utils.GenerateRandomNumbers(3))/100
            };
        }
        #endregion

        public Telegram GetTelegram(string rawJson) => JsonConvert.DeserializeObject<Telegram>(rawJson);

        public string ConvertToJson() => JsonConvert.SerializeObject(this);

        public override string ToString()
        {
            return "{" + Environment.NewLine +
                    $"\"cmd\" : \"{cmd}\"," + Environment.NewLine +
                    $"\"EUI \" : \"{eui}\"," + Environment.NewLine +
                    $"\"ts\" : {ts}," + Environment.NewLine +
                    $"\"ack\" : \"{ack}\"," + Environment.NewLine +
                    $"\"fnct\" : {fnct}," + Environment.NewLine +
                    $"\"port\" : {port}," + Environment.NewLine +
                    $"\"data\" : \"{data}\"," + Environment.NewLine +
                    $"\"freq\" : {freq}," + Environment.NewLine +
                    $"\"rssi\" : {rssi}," + Environment.NewLine +
                    $"\"snr\" : {snr}" + "}";
        }


    }
}
