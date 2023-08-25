using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MethodBox.SimpleCqSDK.Utils
{
    public class BasicJson
    {
        [JsonPropertyName("status")] public string Status { get; set; } = "failed";
        [JsonPropertyName("retcode")] public int Retcode { get; set; } = 0;
        [JsonPropertyName("msg")] public string Msg { get; set; } = "";
        [JsonPropertyName("wording")] public string Wording { get; set; } = "";
        [JsonPropertyName("data")] public object Data { get; set; } = new();
        [JsonPropertyName("echo")] public string Echo { get; set; } = "";
    }
}
