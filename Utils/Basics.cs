using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MethodBox.SimpleCqSDK.Utils
{
    public class Basics
    {
        /// <summary>
        /// 用户信息的基础继承类。
        /// </summary>
        public class UserBasic
        {
            [JsonPropertyName("user_id")]
            public long UserId { get; set; } = 114514;
            [JsonPropertyName("nickname")]
            public string NickName { get; set; } = "myName";
        }
    }
}
