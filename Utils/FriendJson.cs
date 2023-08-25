using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MethodBox.SimpleCqSDK.Utils
{
    /// <summary>
    /// 用于表示好友相关JSON实例结构的导出类。
    /// </summary>
    public class FriendJson
    {
        /// <summary>
        /// 表示用户信息数据。
        /// </summary>
        [Serializable]
        public class UserInfo
        {
            /// <summary>
            /// QQ号
            /// </summary>
            [JsonPropertyName("user_id")]
            public long UserId { get; set; } = 1919810;
            /// <summary>
            /// 昵称
            /// </summary>
            [JsonPropertyName("nickname")]
            public string NickName { get; set; } = "Homo";
            /// <summary>
            /// 性别
            /// </summary>
            [JsonPropertyName("sex")]
            public string Sex { get; set; } = "Male";
            /// <summary>
            /// 年龄
            /// </summary>
            [JsonPropertyName("age")]
            public int Age { get; set; } = 114;
            /// <summary>
            /// Qid
            /// </summary>
            [JsonPropertyName("qid")]
            public string Qid { get; set; } = "ID";
            /// <summary>
            /// QQ等级
            /// </summary>
            [JsonPropertyName("level")]
            public int Level { get; set; } = 32;
            /// <summary>
            /// 登录时长
            /// </summary>
            [JsonPropertyName("login_days")]
            public int LoginDays { get; set; } = 32;
        }

        public class GetUserInfoRequest
        {
            [JsonPropertyName("user_id")]
            public long UserId { get; set; } = 1919810;

            [JsonPropertyName("no_cache")]
            public bool NoCache { get; set; } = false;
        }

        public class BriefUserInfoRoot
        {
            [JsonPropertyName("data")] 
            public BriefUserInfo[] Data { get; set; } = Array.Empty<BriefUserInfo>();
            [JsonPropertyName("message")]
            public string Message { get; set; } = "EMPTY";
            [JsonPropertyName("retcode")]
            public int Retcode { get; set; } = 0;
            [JsonPropertyName("status")]
            public string Status { get; set; } = "failed";
        }

        /// <summary>
        /// 用于表示用户简要信息。
        /// </summary>
        public class BriefUserInfo
        {
            /// <summary>
            /// 用户昵称
            /// </summary>
            [JsonPropertyName("nickname")]
            public string NickName { get; set; } = "Homo";
            /// <summary>
            /// 用户备注名
            /// </summary>
            [JsonPropertyName("remark")]
            public string Remark { get; set; } = "xia";
            /// <summary>
            /// 用户QQ号
            /// </summary>
            [JsonPropertyName("user_id")]
            public long UserId { get; set; } = 114514;
        }

        public class UserIdSignal
        {
            /// <summary>
            /// 指定用户的QQ号
            /// </summary>
            [JsonPropertyName("user_id")]
            public long UserId { get; set; }
        }

    }
}
