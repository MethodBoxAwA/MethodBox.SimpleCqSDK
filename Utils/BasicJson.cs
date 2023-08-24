using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodBox.SimpleCqSDK.Utils
{
    public class BasicJson
    {
        public string status = "failed";
        public int retcode = 0;
        public string msg = "";
        public string wording = "";
        public object data = new();
        public string echo = "";
    }
}
