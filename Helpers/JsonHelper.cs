using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodBox.SimpleCqSDK.Utils;

namespace MethodBox.SimpleCqSDK.Helpers
{
    internal class JsonHelper
    {
        internal BasicJson? DisAssembleJson(string json)
        {
            BasicJson? basicJson =
                System.Text.Json.JsonSerializer.Deserialize<Utils.BasicJson>(json);
            return basicJson;
        }
    }
}
